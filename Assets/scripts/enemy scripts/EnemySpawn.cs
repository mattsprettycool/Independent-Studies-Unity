using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemySpawn : MonoBehaviour {
    public float enemiesKilled;
	public GameObject[] enemyList;
    public Transform[] spawnPoints;
    float timeToSpawn;
    float numberToSpawn;
    int index;
	int index2;
    [SerializeField]
    float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
		timeToSpawn = 20;
        SpawnEnemy();
    }

    void FixedUpdate()
    {
		timer += Time.deltaTime;
		timeToSpawn - (.0001f * enemiesKilled);
        numberToSpawn = enemiesKilled * .125f;
        if(numberToSpawn > 4)
        {
            numberToSpawn = 4;
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
            index = Random.Range(0, spawnPoints.Length);
            index2 = Random.Range(0, enemyList.Length);
            Instantiate(enemyList[index2], spawnPoints[index].position, spawnPoints[index].rotation);
        }
        if (numberToSpawn >= 1)
        {
            for(int i = 0; i < numberToSpawn; i++)
            {
                index = Random.Range(0, spawnPoints.Length);
                index2 = Random.Range(0, enemyList.Length);
                Instantiate(enemyList[index2], spawnPoints[index].position, spawnPoints[index].rotation);
            }
        }
	}
}
