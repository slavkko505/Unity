using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{	
	[SerializeField] Canvas pickUpCanvas;
	[SerializeField] int amountBullets;
	private void Awake() {
		pickUpCanvas.enabled = false;
	}


	 private void OnTriggerStay(Collider other) 
	 {
		if (other.gameObject.tag == "Player")
		{
			pickUpCanvas.enabled = true;
			if (Input.GetKeyDown(KeyCode.E))
			{
				FindObjectOfType<AutomaticGunScriptLPFP>().AddSomeBulets(amountBullets);
				Destroy(gameObject);
				pickUpCanvas.enabled = false;
			}
		}
	 }
	 private void OnTriggerExit(Collider other) 
	 {
		if (other.gameObject.tag == "Player")
		{
			pickUpCanvas.enabled = false;
		}
	 }
}
