using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocationBobber : MonoBehaviour {
	public float transformPos;
	public float amountTransformed;
	void Start(){
		transformPos = .01f;
		amountTransformed = 0;
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
			if (amountTransformed >= 1){
				amountTransformed -= transformPos;
				gameObject.transform.position.Set (transform.position.x, transform.position.y - transformPos, transform.position.z);
			}
			if (amountTransformed >= 0 && amountTransformed < 1) {
				amountTransformed += transformPos;
			}
		}
	}
}
