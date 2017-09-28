using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public float dmgPerAttk;
	public float timeBetweenAttk;
	float timer;
	bool inRange;
	GameObject player;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		dmgPerAttk = .125f;
		timeBetweenAttk = 1;
		inRange = false;
	}	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			inRange = true;
		}
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player" && inRange) {
			playerHealth.TakeDamage (dmgPerAttk);
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			inRange = false;
		}
	}
}