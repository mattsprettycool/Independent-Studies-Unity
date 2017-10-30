using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
	public Transform[] spawnPoints;
	PlayerHealth pHealth;
	PlayerMovement pMovement;
	MusicController musicCont;
	GameObject playerSpawnTrigger;
	int randy;
	public bool inArena;
	// Use this for initialization
	void Start () {
		pHealth = gameObject.GetComponent<PlayerHealth> ();
		pMovement = gameObject.GetComponent<PlayerMovement> ();
		musicCont = gameObject.GetComponent<MusicController> ();
		playerSpawnTrigger = GameObject.FindGameObjectWithTag ("PlayerSpawnTrigger");
		inArena = true;
		musicCont.PlaySong (inArena);
	}
	
	// Update is called once per frame
	void Update () {
		playerSpawnTrigger.transform.Rotate (new Vector3 (playerSpawnTrigger.transform.rotation.x, playerSpawnTrigger.transform.rotation.y + 15, playerSpawnTrigger.transform.rotation.z));
		if (pHealth.currHealth == 0)
		{
			pMovement.speed = 0;
			transform.position = new Vector3 (2, 102, 0);
			pHealth.currHealth = pHealth.startHealth;
			pMovement.speed = .5f;
			inArena = false;
			musicCont.PlaySong (inArena);
		}
	}

	void OnTriggerEnter (Collider other) {
		randy = Random.Range (0, spawnPoints.Length);
		if (other.tag == "PlayerSpawnTrigger") {
			transform.position = spawnPoints[randy].position;
			inArena = true;
			musicCont.PlaySong (inArena);
		}
	}
}
