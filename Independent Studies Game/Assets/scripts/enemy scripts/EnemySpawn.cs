using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemySpawn : MonoBehaviour {
    [SerializeField]
    public float spawnTime;
    public float enemiesKilled;
	public GameObject[] enemyList;
    public Transform[] spawnPoints;
    int howManyToSpawn;
    int index;
	int index2;
    float timer;
	// Use this for initialization
	void Start () {
        spawnTime = 20;
        timer = 0;
        SpawnEnemy();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        spawnTime -= enemiesKilled * .0001f;
        if (timer > spawnTime && spawnTime > 3)
        {
            SpawnEnemy();
            timer = 0;
        }
        else if (timer > spawnTime && spawnTime <= 3)
        {
            spawnTime = 3;
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy () {
        index = Random.Range(0, spawnPoints.Length);
		index2 = Random.Range (0, enemyList.Length);
		if (spawnTime < 18) {
			Instantiate (enemyList[0], spawnPoints [index].position, spawnPoints [index].rotation);
		} else {
			Instantiate(enemyList[index2], spawnPoints[index].position, spawnPoints[index].rotation);	
		}
	}
}
