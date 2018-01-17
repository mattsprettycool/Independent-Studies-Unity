using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//by Jai Saka
public class EnemySpawn : MonoBehaviour {
	public int enemiesInArena;
	int enemyLimit;
    public float enemiesKilled;
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
		if (SceneManager.GetActiveScene().name == "Level1") 
		{
			enemyLimit = 10;
		}
		if (SceneManager.GetActiveScene().name == "Level2")
		{
			enemyLimit = 20;
		}
		//Debug.Log ("Enemy Limit is: "+enemyLimit);
        SpawnEnemy();
		enemiesInArena++;
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
			//Debug.Log ("Spawning Enemy!");
            timer = 0;
        }
		if (Input.GetKeyDown(KeyCode.P)){
			enemiesKilled++;
		}
    }

    void SpawnEnemy () {
        if (numberToSpawn < 1)
        {
			spawnZoneIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
			enemyIndex = UnityEngine.Random.Range(0, enemyList.Length);
			if (enemyList [enemyIndex].GetComponent<EnemyLibrary> ().numKillsToSpawn > enemiesKilled) {
				Instantiate (enemyList [0], spawnPoints [spawnZoneIndex].position, spawnPoints [spawnZoneIndex].rotation);
				enemiesInArena++;
				//Debug.Log ("Enemies in Arena: "+enemiesInArena);
			} else {
				Instantiate (enemyList [enemyIndex], spawnPoints [spawnZoneIndex].position, spawnPoints [spawnZoneIndex].rotation);
				enemiesInArena++;
				//Debug.Log ("Enemies in Arena: "+enemiesInArena); 
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
						enemiesInArena++;
						//Debug.Log ("Enemies in Arena: "+enemiesInArena);
					} else {
						Instantiate (enemyList [enemyIndex], spawnPoints [spawnZoneIndex].position, spawnPoints [spawnZoneIndex].rotation);
						enemiesInArena++;
						//Debug.Log ("Enemies in Arena: "+enemiesInArena);
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
	public int GetEnemiesInArena(){
		return enemiesInArena;
	}
	public int GetEnemyLimit(){
		return enemyLimit;
	}
}
