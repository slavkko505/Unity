using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ZoomGuns : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
	 [SerializeField] float zoomOut = 60f;
	 [SerializeField] float zoomIn = 20f;
	 [SerializeField] float zoomInSensetivity = 0.2f;
	 [SerializeField] float zoomOutSensetivity = 2f;
	 [SerializeField] RigidbodyFirstPersonController fpController;
	

	 bool zoom = false;


	private void OnDisable() {
		ZoomOut();
	}

	 private void Update() {
		 if(Input.GetMouseButtonDown(1)){
			 if(zoom)
			{
				ZoomOut();
			}
			else
			{
				ZoomIn();
			}
		}
	 }

	private void ZoomIn()
	{
		zoom = true;
		fpCamera.fieldOfView = zoomIn;
		fpController.mouseLook.XSensitivity = zoomInSensetivity;
		fpController.mouseLook.YSensitivity = zoomInSensetivity;
	}

	private void ZoomOut()
	{
		zoom = false;
		fpCamera.fieldOfView = zoomOut;
		fpController.mouseLook.XSensitivity = zoomOutSensetivity;
		fpController.mouseLook.YSensitivity = zoomOutSensetivity;
	}
}
