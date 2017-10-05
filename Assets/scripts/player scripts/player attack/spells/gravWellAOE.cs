using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravWellAOE : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.LookAt(Camera.main.transform);
	}
}
