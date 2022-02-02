using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	 [SerializeField] Canvas mainCanvas;
    [SerializeField] float myHealth = 5f;
	 public float MyHealth{get{ return myHealth;}}

	private void Start() {
		mainCanvas.enabled = false;
	}

	 public void MinusHealthPlayer(float amount){
		 myHealth -= amount;
		 if(myHealth <= 0){
			mainCanvas.enabled = true;
			Time.timeScale = 0;
			FindObjectOfType<WeaponSwitch>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		 }
	 }
}
