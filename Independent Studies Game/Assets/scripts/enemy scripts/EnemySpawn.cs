using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    [SerializeField]
    public float spawnTime;
    public float enemiesKilled;
    public GameObject enemy;
    public Transform[] spawnPoints;
    int howManyToSpawn;
    int index;
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
        if (timer > spawnTime && spawnTime >= 3)
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
        Instantiate(enemy, spawnPoints[index].position, spawnPoints[index].rotation);
	}
}
