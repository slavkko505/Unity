using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	[SerializeField] Tower tower;
	[SerializeField] bool isPlaced;
	public bool IsPlayced{ get{return isPlaced;} }

	GridManager gridManager;
	Vector2Int coordinates = new Vector2Int();
	PathFinding pathFinding;


	private void Awake() {
		gridManager = FindObjectOfType<GridManager>();
		pathFinding = FindObjectOfType<PathFinding>();
	}
	private void Start() {
		if(gridManager != null){
			coordinates = gridManager.GetCoordinatesFromPos(transform.position);

			if(!isPlaced){
				gridManager.BlockNode(coordinates);
			}
		}
	}


    private void OnMouseDown() {
		 if(gridManager.GetNode(coordinates).isWalkebl && !pathFinding.WillBlockPath(coordinates))
		 {
			 bool isSuccesfull = tower.CreateTowerPrefab(tower, transform.position);

			if(isSuccesfull)
			{
				gridManager.BlockNode(coordinates);
				pathFinding.RevercePathFinding();
			}
		 }
	 }
}
