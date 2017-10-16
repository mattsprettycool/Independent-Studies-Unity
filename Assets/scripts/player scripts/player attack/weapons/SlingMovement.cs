using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingMovement : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			transform.localRotation = new Quaternion (transform.rotation.x, transform.rotation.y + 15, transform.rotation.z, 0);
		}
	}
}
