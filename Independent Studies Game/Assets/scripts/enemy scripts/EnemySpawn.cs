using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemySpawn : MonoBehaviour {
    public float enemiesKilled;
	public GameObject[] enemyList;
    public Transform[] spawnPoints;
    int howManyToSpawn;
    int index;
	int index2;
    [SerializeField]
    float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
        SpawnEnemy();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 25)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy () {
        index = Random.Range(0, spawnPoints.Length);
		index2 = Random.Range (0, enemyList.Length);
        Instantiate(enemyList[index2], spawnPoints[index].position, spawnPoints[index].rotation);
	}
}
