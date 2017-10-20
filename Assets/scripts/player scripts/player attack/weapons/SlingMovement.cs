using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class SlingMovement : MonoBehaviour {
    public float timeHeld;
	// Use this for initialization
	void Start () {
        timeHeld = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, 0, transform.localRotation.z + 15);
            timeHeld += Time.deltaTime;
		}
        if (Input.GetMouseButtonUp(0))
        {
			transform.localRotation = Quaternion.Euler (new Vector3 (0, 90, 0));            
			timeHeld = 0;
        }
	}
}
