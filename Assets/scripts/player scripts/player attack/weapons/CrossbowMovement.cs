using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class CrossbowMovement : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            gameObject.transform.position.Set(0, 0, gameObject.transform.position.z);
        }
    }
}
