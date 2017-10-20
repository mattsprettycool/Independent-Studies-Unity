using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
	PlayerHealth pHealth;
	PlayerMovement pMovement;
	// Use this for initialization
	void Start () {
		pHealth = gameObject.GetComponent<PlayerHealth> ();
		pMovement = gameObject.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pHealth.currHealth == 0)
		{
			pMovement.speed = 0;
			transform.position = new Vector3 (1, 102, 0);
			pHealth.currHealth = pHealth.startHealth;
			pMovement.speed = .5f;
		}
	}
}
