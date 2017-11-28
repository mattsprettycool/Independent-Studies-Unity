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
		pSpawn = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerSpawn> ();
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
		if (pSpawn.GetArenaState() == true) {
			gameObject.GetComponent<Text> ().text = enSpawn.GetEnemiesKilled () + "/" + killsNeeded;
		}
		if (pSpawn.GetArenaState () == false) {
			gameObject.GetComponent<Text> ().text = enSpawn.GetEnemiesKilled () + "/" + killsNeeded + "\t\t\t\t" + pSpawn.GetPointsAvailable();
		}
	}
	public float GetKillsNeeded(){
		return killsNeeded;
	}
}
