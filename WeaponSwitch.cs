﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

	

    void Start()
    {
        SetActiveWeapon();
    }

	private void Update() {
		int previusWeapon = currentWeapon;

		ProcessKeyInput();
		PocessScrollWheel();

		if(previusWeapon != currentWeapon){
			SetActiveWeapon();
		}
	}

	private void PocessScrollWheel()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			 if(currentWeapon >= transform.childCount - 1){
				 currentWeapon = 0;
			 }else{
				 currentWeapon++;
			 }
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (currentWeapon <= 0)
			{
				currentWeapon = transform.childCount - 1;
			}
			else
			{
				currentWeapon--;
			}
		}
	}

	private void ProcessKeyInput()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			currentWeapon = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			currentWeapon = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentWeapon = 2;
		}
	}

	void SetActiveWeapon(){
		int WeaponIndex = 0;

		foreach (Transform weapon in transform)
		{
			 if(WeaponIndex == currentWeapon){
				 weapon.gameObject.SetActive(true);
			 }else{
				weapon.gameObject.SetActive(false);
			}
			WeaponIndex++;
		}
	}
   
}
