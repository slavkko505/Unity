using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
	 [SerializeField] float MaxRange = 5f;
	 [SerializeField] Color colorRangeTarget = Color.red;
	 [SerializeField] float attackPlayerAmount = 2f;
	 [SerializeField] float rotationSpeed = 1f;
 
	 Animator myAnim;
	 PlayerHealth playerHealth;
	 NavMeshAgent navMeshAgent; 
	 float distacetoTarget = Mathf.Infinity;
	 bool isProvocked = false;
	 CapsuleCollider myCollider;
    EnemyHealh enemyHealth;

    void Start()
    {
		navMeshAgent=GetComponent<NavMeshAgent>();
	   myAnim = GetComponent<Animator>();
		playerHealth = FindObjectOfType<PlayerHealth>();
		myCollider = GetComponent<CapsuleCollider>();
		enemyHealth = GetComponent<EnemyHealh>();
    }

    void Update()
    {
		 if(enemyHealth.IsDead)
		 {
			 enabled = false;
			 navMeshAgent.enabled = false;
			 enemyHealth.enabled = false;
		 }
		distacetoTarget = Vector3.Distance(target.position, transform.position);

		if(isProvocked)
		{
			EngageTarget();
		}
		else if(distacetoTarget <= MaxRange)
		{
			isProvocked = true;
		}
			
	 }		 

	 void EngageTarget()
	 {
		FaceTarget();
		if(distacetoTarget >= navMeshAgent.stoppingDistance){
			ChaseTarget();
			myAnim.SetBool("atack", false);
			myAnim.SetBool("run", true);
		}
		else if(distacetoTarget <= navMeshAgent.stoppingDistance){
			myAnim.SetBool("run", false);
			myAnim.SetBool("atack", true);
		}
	 }

	 void ChaseTarget(){
		 if(navMeshAgent.enabled == false){return;}
		 navMeshAgent.SetDestination(target.position);
	 }

	 public void PlayerMinuseHealth(){
		playerHealth.MinusHealthPlayer(attackPlayerAmount);
	 }
	 private void OnDrawGizmosSelected() {
		Gizmos.color = colorRangeTarget;
		Gizmos.DrawSphere(transform.position, MaxRange);
	 }

	 void FaceTarget(){
		 Vector3 direction = (target.position - transform.position).normalized;
		 Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y));
	 	 transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
	 }

	 public void OnTakenDamage(){
		 isProvocked = true;
	 }
}
