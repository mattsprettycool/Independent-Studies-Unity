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
	// Use this for initialization
	void Start () {
        spawnTime = 10;
        InvokeRepeating("SpawnEnemy", 1, spawnTime);
	}

    void FixedUpdate()
    {
        spawnTime -= enemiesKilled * .001f;
    }

    void SpawnEnemy () {
        index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[index].position, spawnPoints[index].rotation);
	}
}
