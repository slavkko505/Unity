using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField] int towerCost = 75;


    public bool CreateTowerPrefab(Tower tower, Vector3 pos)
	 {
		Bank bank = FindObjectOfType<Bank>();

		if(bank == null){return false;}
		 
		 if (bank.CurrentCapital >= towerCost){
			 bank.WindrawMoney(towerCost);
			 Instantiate(tower, pos, Quaternion.identity);
		 	 return true;
		 }
		 else
		 {
			 return false;
		 }
		 
	 }
}
