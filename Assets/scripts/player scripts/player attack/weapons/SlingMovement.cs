﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class SlingMovement : MonoBehaviour {
	GameObject player;
    public float timeHeld;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        timeHeld = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, 0, transform.rotation.z + 15);
            timeHeld += Time.deltaTime;
		}
        if (Input.GetMouseButtonUp(0))
        {
			transform.rotation = new Quaternion (0, 0, 0, 0);
            timeHeld = 0;
        }
	}
}
