using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillManager : MonoBehaviour {
    EnemySpawn enSpawn;
    public PlayerSpawn pSpawn;
    float killsNeeded;
	// Use this for initialization
	void Start () {
        enSpawn = GameObject.FindGameObjectWithTag("enemymanager").GetComponent<EnemySpawn>();
        killsNeeded = 20;
		if (SceneManager.GetActiveScene().name == "Level") 
		{
			killsNeeded = 20;
		}
		if (SceneManager.GetActiveScene().name == "Level2")
		{
            killsNeeded = 40;
        }
	}
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text> ().text = enSpawn.GetEnemiesKilled () + "/" + killsNeeded;
	}
	public float GetKillsNeeded(){
		return killsNeeded;
	}
}
