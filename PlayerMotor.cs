using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	Transform target;
	NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

	private void Update() {
		if(target != null){
			agent.SetDestination(target.position);
			FaceTarget();
		}
	}
	private void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime *5f);
	}

	public void MoveToPointPlayer(Vector3 point)
	 {
		 agent.SetDestination(point);
	 }

	 public void FoolwTarget(Interaction newTarget){
		 agent.stoppingDistance = newTarget.radius * 0.8f;
		 agent.updateRotation = false;
		 target = newTarget.InteractibleTransform;
	 }

	public void StopFoolwTarget()
	{
		agent.stoppingDistance = 0f;
		agent.updateRotation = true;
		target = null;
	}
}
