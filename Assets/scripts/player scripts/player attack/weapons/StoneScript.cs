using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour {
    public SlingMovement sling;
    float timer;
    float timeBeforeDeletion;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        timer = 0;
        timeBeforeDeletion = 10;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(250 * 1 + (.01f * sling.timeHeld), 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
