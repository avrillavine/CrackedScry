using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CController : MonoBehaviour {

	public float speed = 2.0f;
	public float backup_speed = 0.5f;
	public float jumpSpeed = 4.0f;
	public float gravity = 20.0f;

	public float horizTurnSpeed = 3f;

	public Camera cam;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	void Start()
	{
		controller=GetComponent<CharacterController>();
		//camera=GetComponent<Camera>();
		// let the gameObject fall down
		//gameObject.transform.position=new Vector3(0, 5, 0);
	}

	void Update()
	{
		//locks mouse 
		if(Input.GetKey(KeyCode.Escape))
		{
			Cursor.lockState=CursorLockMode.Locked;
			Cursor.lockState=CursorLockMode.Confined;
			Cursor.visible=true;
		}
		else
		{
			Cursor.lockState=CursorLockMode.None;
			Cursor.visible=false;
		}	

		if(controller.isGrounded)
		{
			// We are grounded, so recalculate
			// move direction directly from axes

			moveDirection=new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));

			moveDirection=transform.TransformDirection(moveDirection);
			moveDirection=moveDirection*speed;
			if(Input.GetKeyDown(KeyCode.S))
			{
				moveDirection = moveDirection * backup_speed;
			}
			//Allows for direction vector to move in direction that cursor turns to
			moveDirection+=cam.transform.right*Input.GetAxis("Horizontal")*speed/2.0f;
			//Function for rotating the player with the cursor horizontally
			ApplyPlayerRotation();
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}

		// Apply gravity
		moveDirection.y=moveDirection.y-(gravity*Time.deltaTime);

		// Move the controller
		controller.Move(moveDirection*Time.deltaTime);
	}
	//Horizontal Mouse Look
	void ApplyPlayerRotation()
	{
		gameObject.transform.Rotate(0, Input.GetAxis("Mouse X")*horizTurnSpeed, 0);
	}


}
