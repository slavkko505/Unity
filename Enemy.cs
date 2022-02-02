using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int enemyCostRewald = 25;
	[SerializeField] int enemyCostPenalty = 25;
	Bank bank;
	 void Start()
	{
		bank = FindObjectOfType<Bank>();
	}
   public void RewaldCostEnemy(){
		if(bank == null){return;}
		bank.DepositMoney(enemyCostRewald);
	}
	public void PenaltyCostEnemy()
	{
		if (bank == null) { return; }
		bank.WindrawMoney(enemyCostPenalty);
	}
}
