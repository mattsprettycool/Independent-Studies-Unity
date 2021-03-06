﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyMageAttack : MonoBehaviour {
	[SerializeField]
	public int dmgPerAttk;
	public float timeBetweenAttk;
	public float timer, turnSpeed, thrallTimer, timeToSpawnThrall;
	public bool inRange;
	GameObject player;
	public GameObject thrall;
    public Transform enFireBoltSpawn;
	public GameObject enemyFirebolt;
	EnemySpawn enSpawn;
    ArtificialTimeManager realTime;
	// Use this for initialization
	void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        enSpawn = GameObject.FindGameObjectWithTag ("enemymanager").GetComponent<EnemySpawn>();
		player = GameObject.FindGameObjectWithTag("Player");
		dmgPerAttk = 5;
		timeBetweenAttk = 2;
		thrallTimer = 0;
		timeToSpawnThrall = 60;
		inRange = false;
		turnSpeed = 10;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (realTime.IsTimeOn())
        {
            Vector3 dir = (player.gameObject.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), Time.deltaTime * turnSpeed);
            timer += Time.deltaTime;
            thrallTimer += Time.deltaTime;
            if (timer >= timeBetweenAttk && inRange)
            {
                Instantiate(enemyFirebolt, enFireBoltSpawn.position, enFireBoltSpawn.rotation);
                timer = 0;
            }
            if (thrallTimer >= timeToSpawnThrall)
            {
                Instantiate(thrall, transform.position, transform.rotation);
                thrallTimer = 0;
            }
        }
    }

	public void SetInRange(bool boo1){
		inRange = boo1;
	}
}