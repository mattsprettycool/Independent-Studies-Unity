using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemySpawn : MonoBehaviour {
    public float enemiesKilled;
	public GameObject[] enemyList;
    public Transform[] spawnPoints;
    float timeToSpawn, numberToSpawn, spawnZoneArea;
	int spawnZoneIndex, enemyIndex;
    [SerializeField]
    float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
		timeToSpawn = 20;
        SpawnEnemy();
		spawnZoneArea = 3.75f * 3.75f;
    }

    void FixedUpdate()
    {
		timer += Time.deltaTime;
		timeToSpawn -= (.0001f * enemiesKilled);
        numberToSpawn = enemiesKilled * .125f;
        if(numberToSpawn > 3)
        {
            numberToSpawn = 3;
        }
		if (timeToSpawn < 7.5f) {
			timeToSpawn = 7.5f;
		}
		if (timer > timeToSpawn)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy () {
        if (numberToSpawn < 1)
        {
			spawnZoneIndex = Random.Range(0, spawnPoints.Length);
			enemyIndex = Random.Range(0, enemyList.Length);
			Instantiate(enemyList[enemyIndex], spawnPoints[spawnZoneIndex].position, spawnPoints[spawnZoneIndex].rotation);
        }
        if (numberToSpawn >= 1)
        {
            for(int i = 0; i < numberToSpawn; i++)
            {
                spawnZoneIndex = Random.Range(0, spawnPoints.Length);
                enemyIndex = Random.Range(0, enemyList.Length);
				Instantiate(enemyList[enemyIndex], spawnPoints[spawnZoneIndex].position, spawnPoints[spawnZoneIndex].rotation);
            }
        }
	}
}
