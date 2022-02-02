using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealh : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
	 Animator anim;

	 bool isdead = false;
	 public bool IsDead{get{return isdead;}}


	 private void Start() {
		 anim = GetComponent<Animator>();
	 }

	 public void MinusHealth(float damage)
	 { 
		 BroadcastMessage("OnTakenDamage");
		 hitPoints -= damage;
		 if(hitPoints <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		if(isdead){return;}
		isdead = true;
		anim.SetTrigger("die");
	}
}
