using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour {
	Transform cameraTransform;
	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		transform.rotation = Quaternion.LookRotation(transform.position - GameObject.FindGameObjectWithTag("Player").transform.position);
		GameObject.Destroy (gameObject, 2);	
	}
	void FixedUpdate(){
		gameObject.transform.Translate (0, .1f, 0);
	}
}
