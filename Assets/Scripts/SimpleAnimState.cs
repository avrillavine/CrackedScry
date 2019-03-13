﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimState : MonoBehaviour {
	public Animator anim;
	//Magnifying Glass
	public GameObject mg;
	public enum ACTION
	{
		Idle,
		Walk,
		Backup,
		Strafe,
		Look
		//Jump
	}
	public ACTION currentAction = ACTION.Idle;
	// Use this for initialization
	void Start () {
		
	}
	public void SwitchTransition(ACTION nextState)
	{

		switch(nextState)
		{
			case ACTION.Idle:
				anim.SetBool("IsIdle", true);
				anim.SetBool("IsWalking", false);
				anim.SetBool("IsBackingUp", false);
				anim.SetBool("IsStrafing", false);
				break;
			case ACTION.Walk:
				anim.SetBool("IsWalking", true);
				anim.SetBool("IsIdle", false);
				anim.SetBool("IsBackingUp", false);
				anim.SetBool("IsStrafing", false);
				break;
			case ACTION.Backup:
				anim.SetBool("IsBackingUp", true);
				anim.SetBool("IsWalking", false);
				anim.SetBool("IsIdle", false);
				anim.SetBool("IsStrafing", false);
				break;
			case ACTION.Strafe:
				anim.SetBool("IsStrafing", true);
				anim.SetBool("IsBackingUp", false);
				anim.SetBool("IsWalking", false);
				anim.SetBool("IsIdle", false);
				break;
			case ACTION.Look:
				anim.SetTrigger("Look");
				anim.ResetTrigger("Look");
				break;
			////case ACTION.Jump:
			////	anim.SetTrigger("Jump");
			////	anim.ResetTrigger("Jump");
			////	break;
				//default:
				//	break;
		}
		Debug.Log("Player is: "+nextState);
		currentAction=nextState;
	}
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			SwitchTransition(ACTION.Walk);
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			SwitchTransition(ACTION.Backup);
		}
		if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))
		{
			SwitchTransition(ACTION.Strafe);
		}
		if(Input.GetKeyDown(KeyCode.G))
		{
			anim.SetTrigger("Look");
			Debug.DrawRay(mg.transform.position, mg.transform.forward * 25.0f,Color.red,20.0f,true);
		}
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	anim.SetTrigger("Jump");
		//	//SwitchTransition(ACTION.Jump);
		//}

		if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.G))
		{
			SwitchTransition(ACTION.Idle);
			//anim.ResetTrigger("Jump");
		}

	}
}
