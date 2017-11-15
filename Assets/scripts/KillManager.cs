using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillManager : MonoBehaviour {
    EnemySpawn enSpawn;
    PlayerSpawn pSpawn;
    float killsNeeded;
	// Use this for initialization
	void Start () {
        enSpawn = GameObject.FindGameObjectWithTag("enemymanager").GetComponent<EnemySpawn>();
        pSpawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpawn>();
        killsNeeded = 20;
        if (pSpawn.GetCurrentScene().Equals("Level2"))
        {
            killsNeeded = 40;
        }
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = "Kills: " + enSpawn.enemiesKilled + "    Kills Needed: " + (killsNeeded - enSpawn.enemiesKilled);
	}
}
