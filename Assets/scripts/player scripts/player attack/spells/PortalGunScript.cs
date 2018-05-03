using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunScript : MonoBehaviour {
	public GameObject portal;
	SpellManager spm;
	GameObject player;
	GameObject spawnedPortal;
	// Use this for initialization
	void Start () {
		spm = gameObject.GetComponent<SpellManager> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*when player left clicks, raycast a point on the ground, spawn portal on it if there is not already a portal on the map
		 *If there is a portal on the map, send the player to it
		 *when the player right clicks, destroy whatever portal is already on the map*/
		if (Input.GetMouseButtonDown (0) && GameObject.FindGameObjectWithTag("Portal") == null && spm.IsOffCooldown()) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.forward, out hit, 20)){
				Instantiate(portal, hit.point, Quaternion.Euler(new Vector3 (90, 0, 0)));
			}
		}
		if (Input.GetMouseButtonDown (0) && !(GameObject.FindGameObjectWithTag ("Portal") == null) && spm.IsOffCooldown()) {
			player.transform.position = GameObject.FindGameObjectWithTag ("Portal").transform.position;
		}
		if (Input.GetMouseButtonDown (1) && !(GameObject.FindGameObjectWithTag ("Portal") == null)) {
			GameObject.Destroy (GameObject.FindGameObjectWithTag ("Portal"));
		}
		if (spm.IsOffCooldown())
		{
			gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(1, 1);
		}
		else
			gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(1, 0);
		gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(0, spm.GetCooldownRatio());
	}
}
