﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpreadShotBulletScript : MonoBehaviour {
	string debug;
	ArtificialTimeManager realTime;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().AddRelativeForce (0, 1000, 0);
		realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
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
				col.GetComponent<EnemyHealth>().TakeDamage(gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit);
			}
			catch (Exception e)
			{
				debug += "\n" + e;
			}
		}
	}

}
