using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] Camera FPCamera;
	[SerializeField] float range = 100f;
	[SerializeField] float damage = 30f;
	[SerializeField] ParticleSystem muzzleFlash;
	[SerializeField] GameObject HitFlashRange; 
	[SerializeField] float TimeBetweanShoot = 0.3f;
	[SerializeField] Ammo ammo;
	[SerializeField] AmmoType ammoType;

	bool isCanShoot = true;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && isCanShoot)
		  {
			  if (ammo == null){return;}
			  if(ammo.Ammolength(ammoType) > 0){
				 StartCoroutine(Shoot());
			  }else{
				  Debug.Log("Dont have anaf ammo");
				  return;
			  }
		  }
    }

	 IEnumerator Shoot()
	 {	
		 isCanShoot = false;
		 ProcessRaycast();
		 PlayMuzzle();
		 ammo.DecreaseAmmo(ammoType);
		 yield return new WaitForSeconds(TimeBetweanShoot);
		 isCanShoot = true;
	}
	 void PlayMuzzle(){
		 muzzleFlash.Play();
	 }
	 void ProcessRaycast(){
		RaycastHit hit;
		if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
		{
			HitEffectRange(hit);

			EnemyHealh target = hit.transform.GetComponent<EnemyHealh>();
			if (target == null) { return; }
			target.MinusHealth(damage);
		}
		else
		{
			return;
		}
	 }
	 void HitEffectRange(RaycastHit hit){
		GameObject hitEffect = Instantiate(HitFlashRange, hit.point, Quaternion.LookRotation(hit.normal));
		Destroy(hitEffect, 0.1f);
	 }
}
