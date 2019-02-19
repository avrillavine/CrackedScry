using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructableObj : MonoBehaviour {

	public GameObject remains;
	//public AudioClip breaking_sound;

	// Use this for initialization
	void Start () {
		//isDead=false;
		//GetComponent<AudioSource>().playOnAwake = false;
		//GetComponent<AudioSource>().clip = breaking_sound;
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKey(KeyCode.Space))
		//{
		//	Instantiate(remains, remains.transform.position, remains.transform.rotation);
		//	Destroy(gameObject);
			//DestroyObj();
			//isDead=true;
		//}
	}

	private void OnTriggerEnter(Collider other)
	{
		//if (other.GetComponent<Collider>().tag == "Enemy")
		//{
		//GetComponentInChildren<Animator>().SetTrigger("fall");
		//animator.SetTrigger("fall");
		DestroyObj();
		//Instantiate(remains, remains.transform.position, remains.transform.rotation);
		//	Destroy(gameObject);
		//GetComponent<AudioSource>().PlayOneShot(breaking_sound);
		Debug.Log("Vase Hit!");
		//}
	}

	private void DestroyObj()
	{

		Instantiate(remains, remains.transform.position, remains.transform.rotation);
		Destroy(gameObject);
	}

	//private void RebuildObj()
	//{
	//	if(!isDead)
	//	{
	//		Instantiate(gameObject, transform.position, transform.rotation);
	//	}
	//	else
	//	{

	//	}
		
	//}
}
