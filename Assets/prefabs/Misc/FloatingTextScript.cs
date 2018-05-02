using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour {
	Transform cameraTransform;
	float randy;
	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		transform.rotation = Quaternion.LookRotation(transform.position - GameObject.FindGameObjectWithTag("Player").transform.position);
		GameObject.Destroy (gameObject, 2);	
		randy = Random.Range (-.1f, .1f);
	}
	void FixedUpdate(){
		transform.rotation = Quaternion.LookRotation(transform.position - GameObject.FindGameObjectWithTag("Player").transform.position);
		gameObject.transform.Translate (randy, .1f, 0);
	}
}
