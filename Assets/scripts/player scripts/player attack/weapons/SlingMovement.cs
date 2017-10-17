using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class SlingMovement : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, 0, transform.rotation.z + 15);
		}
        if (Input.GetMouseButtonUp(0))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
	}
}
