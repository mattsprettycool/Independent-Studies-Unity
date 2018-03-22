using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpreadShotBulletScript : MonoBehaviour {
	string debug;
	float timer;
	Vector3 storedVel;
	ArtificialTimeManager realTime;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		timer = 0;
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddRelativeForce (0, 0, 1000);
		realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
	}
	void FixedUpdate ()
	{
		if (realTime.IsTimeOn())
		{
			if(rb.velocity == Vector3.zero)
			{
				rb.velocity = storedVel;
			}
			if (timer >= gameObject.GetComponent<ProjectileDamageLibrary> ().travelTime)
			{
				GameObject.Destroy(gameObject);
			}
			timer += Time.deltaTime;
		}
		else
		{
			if(rb.velocity!=Vector3.zero)
				storedVel = rb.velocity;
			rb.velocity = Vector3.zero;
		}
	}
	
	// Update is called once per frame
	private void OnTriggerEnter(Collider col)
	{
		bool ignoreList = col.tag != "Player" && col.tag != "attacks" && col.name != "ProjectileSpawn" && col.tag != "ignoredByFB";
		bool destroyList = col.tag == "Enemies" || col.tag == "Floor" || col.tag == "Wall";
		if (ignoreList&&destroyList&& realTime.IsTimeOn())
		{
			GameObject.Destroy(this.gameObject);
		}
		if (col.tag == "Enemies"&& realTime.IsTimeOn())
		{
			try
			{
				Debug.Log("Dealing " + (gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit + gameObject.transform.localScale.x) + " damage.");
				col.GetComponent<EnemyHealth>().TakeDamage(gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit + gameObject.transform.localScale.x);
			}
			catch (Exception e)
			{
				debug += "\n" + e;
			}
		}
	}

}
