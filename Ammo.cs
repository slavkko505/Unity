using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField] AmmoSlot[] ammoSlots;
	
	[System.Serializable]
	 class AmmoSlot{
		 public AmmoType ammotype;
		 public int countbulets;
	 }

	 public int Ammolength(AmmoType ammoType)
	 {
		 return SerchAmmoINslot(ammoType).countbulets;
    }
	 
	 public void DecreaseAmmo(AmmoType ammoType){
		 if(SerchAmmoINslot(ammoType).countbulets > 0){
			SerchAmmoINslot(ammoType).countbulets--;
		 }
	 }

	public void AddAmmo(AmmoType ammoType, int amount)
	{
		if (SerchAmmoINslot(ammoType).countbulets > 0)
		{
			SerchAmmoINslot(ammoType).countbulets += amount;
		}
	}

	 AmmoSlot SerchAmmoINslot(AmmoType ammoType){
		foreach (AmmoSlot slot in ammoSlots)
		{
			 if(slot.ammotype == ammoType){
				 return slot;
			 }
		}
		return null;
	}
}
