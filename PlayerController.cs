using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] LayerMask movementMask;

	 Camera cam;
	 PlayerMotor motor;

	 public Interaction focus;

    void Start()
    {
        cam = Camera.main;
		  motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
	    if (EventSystem.current.IsPointerOverGameObject())
	    {
		    return;
	    }
	    
		 // go click
        if(Input.GetMouseButtonDown(0))
		  {
			  Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			  RaycastHit hit;

			  if(Physics.Raycast(ray, out hit, 100, movementMask))
			  {
				  motor.MoveToPointPlayer(hit.point);

				  RemoveFocus();
			  }
		  }

		// focus click
		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			{
				Interaction interacteble = hit.collider.GetComponent<Interaction>();

				if(interacteble != null){
					SetFocus(interacteble);
				}
				
			}
		}
	}
	private void SetFocus(Interaction newFocus)
	{
		if(newFocus != focus){
			if(focus != null){
				focus.OnDefocus();
			}
			focus = newFocus;
			motor.FoolwTarget(newFocus);
		}
		newFocus.OnFocus(transform);
	}
	private void RemoveFocus()
	{
		if(focus != null){
			focus.OnDefocus();
		}
		focus = null;
		motor.StopFoolwTarget();
	}
}
