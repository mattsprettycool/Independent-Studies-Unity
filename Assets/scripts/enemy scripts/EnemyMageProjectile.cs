using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageProjectile : MonoBehaviour {
	float timer;
	float timeBeforeDeletion;
	Rigidbody rb;
	GameObject player;
	PlayerHealth plyHlth;
	string buglog;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		plyHlth = player.GetComponent<PlayerHealth> ();
		timer = 0;
		timeBeforeDeletion = 5.5f;
		rb = gameObject.GetComponent<Rigidbody>();
		rb.AddRelativeForce(new Vector3(1000f, 0f, 0f));
	}

	// Update is called once per frame
	void FixedUpdate ()
	{

		if (timer >= timeBeforeDeletion)
		{
			GameObject.Destroy(gameObject);
		}
		timer += Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Enemies" || other.tag != "ignoredByFB")
		{
			if (other.tag == "Player") {
				try {
					plyHlth.TakeDamage (this.gameObject.GetComponent<ProjectileDamageLibrary> ().dmgPerHit);
					GameObject.Destroy(gameObject);
				}
				catch (Exception e){
					buglog +="\n" + e;
				}
			}
		}
	}
}
