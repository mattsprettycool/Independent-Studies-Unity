﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//by Jai Saka
public class EnemySpawn : MonoBehaviour {
	int enemiesInArena, enemyLimit;
    float enemiesKilled;
	public GameObject[] enemyList;
    public Transform[] spawnPoints;
    float timeToSpawn, numberToSpawn;
	int spawnZoneIndex, enemyIndex;
	string debug;
    [SerializeField]
    float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
		timeToSpawn = 20;
		if (SceneManager.GetActiveScene().name == "Level") 
		{
			enemyLimit = 10;
		}
		if (SceneManager.GetActiveScene().name == "Level2")
		{
			enemyLimit = 20;
		}
		//Debug.Log (enemyLimit);
        SpawnEnemy();
		IncreaseEnemiesInArena();
		//Debug.Log (enemiesInArena);
    }

    void FixedUpdate()
    {
		timer += Time.deltaTime;
		timeToSpawn -= (.001f * enemiesKilled);
        numberToSpawn = enemiesKilled * .125f;
        if(numberToSpawn > 3)
        {
            numberToSpawn = 3;
        }
		if (timeToSpawn < 7.5f) {
			timeToSpawn = 7.5f;
		}
		if (timer > timeToSpawn && enemiesInArena < enemyLimit)
        {
            SpawnEnemy();
            timer = 0;
        }
		if (Input.GetKeyDown(KeyCode.P)){
			IncreaseKillCount ();
		}
    }

    void SpawnEnemy () {
        if (numberToSpawn < 1)
        {
			spawnZoneIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
			enemyIndex = UnityEngine.Random.Range(0, enemyList.Length);
			if (enemyList [enemyIndex].GetComponent<EnemyLibrary> ().numKillsToSpawn > enemiesKilled) {
				Instantiate (enemyList [0], spawnPoints [spawnZoneIndex].position, spawnPoints [spawnZoneIndex].rotation);
				IncreaseEnemiesInArena();
				//Debug.Log (enemiesInArena);
			} else {
				Instantiate (enemyList [enemyIndex], spawnPoints [spawnZoneIndex].position, spawnPoints [spawnZoneIndex].rotation);
				IncreaseEnemiesInArena();
				//Debug.Log (enemiesInArena);
			}
        }
        if (numberToSpawn >= 1)
        {
            for(int i = 0; i < numberToSpawn; i++)
            {
                spawnZoneIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
                enemyIndex = UnityEngine.Random.Range(0, enemyList.Length);
				try{
					if (enemyList [enemyIndex].GetComponent<EnemyLibrary> ().numKillsToSpawn > enemiesKilled) {
						Instantiate (enemyList [0], spawnPoints [spawnZoneIndex].position, spawnPoints [spawnZoneIndex].rotation);
						IncreaseEnemiesInArena();
						//Debug.Log (enemiesInArena);
					} else {
						Instantiate (enemyList [enemyIndex], spawnPoints [spawnZoneIndex].position, spawnPoints [spawnZoneIndex].rotation);
						IncreaseEnemiesInArena();
						//Debug.Log (enemiesInArena);
					}	
				}
				catch (Exception e){
					debug += e;
				}
            }
        }
	}
	public float GetEnemiesKilled(){
		return enemiesKilled;
	}
	public void IncreaseKillCount(){
		enemiesKilled++;
	}
	public void IncreaseEnemiesInArena(){
		enemiesInArena++;
	}
	public void DecreaseEnemiesInArena(){
		enemiesInArena--;
	}
}
