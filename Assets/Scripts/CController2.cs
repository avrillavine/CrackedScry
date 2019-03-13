using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CController2 : MonoBehaviour
{
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	public float horizTurnSpeed = 3f;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	public Camera cam;
	void Start()
	{
		controller = GetComponent<CharacterController>();

		// let the gameObject fall down
		gameObject.transform.position = new Vector3(0, 1, 0);
	}

	void Update()
	{
		//For cursor 
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;


		if (controller.isGrounded)
		{
			// We are grounded, so recalculate
			// move direction directly from axes

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection = moveDirection * speed;

			//Allows for direction vector to move in direction that cursor turns to
			moveDirection += cam.transform.right * Input.GetAxis("Horizontal") * speed / 2.0f;
			//Function for rotating the player with the cursor horizontally
			ApplyPlayerRotation();

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}

		// Apply gravity
		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
	}

	//Horizontal Mouse Look
	void ApplyPlayerRotation()
	{
		gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * horizTurnSpeed, 0);
	}
}
