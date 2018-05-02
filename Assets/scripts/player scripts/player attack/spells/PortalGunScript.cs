using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunScript : MonoBehaviour {
	public GameObject portal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*when player left clicks, raycast a point on the ground, spawn portal on it if there is not already a portal on the map
		 *If there is a portal on the map, send the player to it
		 *when the player right clicks, destroy whatever portal is already on the map*/
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.forward, out hit, 20)){
				Instantiate(portal, hit.point, hit.transform.rotation);
			}
		}
	}
}
