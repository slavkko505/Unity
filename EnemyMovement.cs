using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Node> path = new List<Node>();
    [SerializeField] [Range(0f,5f)]float speed = 1f;

	 Enemy enemy;
	 PathFinding pathFinding;
    GridManager gridManager;

    void OnEnable()
    {
		  ResetOnStart();
		  RecaculatePath(true);
    }

	 private void Awake() {
		 enemy = GetComponent<Enemy>();
		pathFinding = FindObjectOfType<PathFinding>();
		gridManager = FindObjectOfType<GridManager>();

	 }
	 	void ResetOnStart(){
			transform.position = gridManager.GetVectorFromCoor(pathFinding.StartCoordinate); 
		}

	 void RecaculatePath(bool reset)
	 {
		 Vector2Int coordinates = new Vector2Int();
		if(reset)
		{
			coordinates = pathFinding.StartCoordinate;
		}
		else
		{
			coordinates = gridManager.GetCoordinatesFromPos(transform.position);
		}
		
		StopAllCoroutines();
		path.Clear();
		path = pathFinding.GetNewPath(coordinates);
		StartCoroutine(MoveEnemyToPoint());

	}

	void FinishPoint(){
		enemy.PenaltyCostEnemy();
		gameObject.SetActive(false);
	}

    IEnumerator MoveEnemyToPoint()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 StartPos = transform.position;
            Vector3 EndPos = gridManager.GetVectorFromCoor(path[i].coordinates);

            transform.LookAt(EndPos);

            float timeToMove = 0f;

            while(timeToMove < 1)
            {
                timeToMove += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(StartPos, EndPos, timeToMove);
                yield return new WaitForEndOfFrame();
            }
        }

		  FinishPoint();
    }
}
