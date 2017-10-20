using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class StatSpawn : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject[] statTypes;
    int index;
    int index2;
    float timer;
    public float spawnTime;
    // Use this for initialization
    void Start () {
        spawnTime = 60;
        timer = 0;
        SpawnStatPickup();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnStatPickup();
            timer = 0;
        }
    }
    void SpawnStatPickup()
    {
        index = Random.Range(0, spawnPoints.Length);
        index2 = Random.Range(0, statTypes.Length);
        Instantiate(statTypes[index2], spawnPoints[index].position, spawnPoints[index].rotation);
    }
}
