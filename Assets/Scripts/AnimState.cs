using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimState : MonoBehaviour {

	public Animator anim;

	//public bool keypressed;

	public enum ACTION
	{
		Idle,
		Walk,
		Backup,
		Strafe,
		Jump
	}
	public ACTION currentAction = ACTION.Idle;

	//public enum INPUT_EVENT
	//{
	//	Up,
	//	Down
	//}
	//public INPUT_EVENT currentInput = INPUT_EVENT.Up;



	// Use this for initialization
	void Start () {
		//anim=GetComponent<Animator>();
		//keypressed=false;
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
				anim.SetBool("IsIdle", false);
				anim.SetBool("IsBackingUp", true);
				anim.SetBool("IsWalking", false);
				anim.SetBool("IsStrafing", false);
				break;
			case ACTION.Strafe:
				anim.SetBool("IsWalking", false);
				anim.SetBool("IsStrafing", true);
				anim.SetBool("IsIdle", false);
				anim.SetBool("IsBackingUp", false);
				break;
			case ACTION.Jump:
				anim.SetTrigger("Jump");
				anim.ResetTrigger("Jump");
				break;
			//default:
			//	break;
		}
		Debug.Log("Player is: "+nextState);
		currentAction=nextState;
	}

	//public void Controls(INPUT_EVENT input_e)
	//{
	//borrowed from https://answers.unity.com/questions/55496/any-way-to-key-just-keydown-and-just-keyup-events.html
	//Event e = Event.current;
	//if(e.type==EventType.KeyDown)
	//{
	//	if(Input.GetKeyDown(e.keyCode))
	//	{
	//		Debug.Log("Down: "+e.keyCode);
	//	}
	//}
	//if(e.type==EventType.KeyDown)
	//{
	//	Debug.Log("Up: "+e.keyCode);
	//}
	//Event e = Event.current;
	//if(e.isKey&&e.type==EventType.KeyUp)
	//{
	//	switch(e.keyCode)
	//	{
	//		case KeyCode.Space:
	//			break;
	//		case KeyCode.W:
	//			currentAction=ACTION.Walk;
	//			break;
	//	}
	//}
	//switch(Event event)
	//{
	//	case INPUT_EVENT.Up:

	//		break;
	//	case INPUT_EVENT.Down:
	//		break;
	//	default:
	//		break;
	//}
	//}

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
		if(Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetTrigger("Jump");
			//SwitchTransition(ACTION.Jump);
		}

		if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.Space))
		{
			SwitchTransition(ACTION.Idle);
			anim.ResetTrigger("Jump");
		}

	}
}
