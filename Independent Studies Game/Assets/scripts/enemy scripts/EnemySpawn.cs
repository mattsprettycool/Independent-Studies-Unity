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
        spawnTime = 10;
        timer = 0;
	}

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        spawnTime -= enemiesKilled * .00001f;
        if (timer > spawnTime)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy () {
        index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[index].position, spawnPoints[index].rotation);
	}
}
