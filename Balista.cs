using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
    [SerializeField] Transform weapon;
	 [SerializeField] ParticleSystem myParticleShot;
	 [SerializeField] float maxDistance = 15f;
	 Transform enemyTarget;


    void Start()
    {
        enemyTarget = FindObjectOfType<EnemyMovement>().transform;
    }
    void Update()
    {
        AimWeapon();
		  SetClosestEnemy();
    }


	 void SetClosestEnemy(){
			Enemy[] enemys = FindObjectsOfType<Enemy>();
			Transform clossestTarget = null;
			float defoltDist = Mathf.Infinity;

			foreach (var item in enemys)
			{
				 float currentDist = Vector3.Distance(transform.position, item.transform.position);
				 if (currentDist < defoltDist){
					 	clossestTarget = item.transform;
						defoltDist = currentDist;
				 }
			}

			enemyTarget = clossestTarget;
	 }
	 void ChechDistanceForShot(bool isActive){
			var ParticleEmmision = myParticleShot.emission;
			ParticleEmmision.enabled = isActive;
		 
	 }
	 void AimWeapon()
	 {
		 weapon.LookAt(enemyTarget);

		if (Vector3.Distance(transform.position, enemyTarget.position) <= maxDistance){
			ChechDistanceForShot(true);
		}else{
			ChechDistanceForShot(false);
		}
	 }
}
