using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//by Jai Saka
public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    public float startHealth;
    public float currHealth;
    float timer;
    public EnemySpawn enemySpawn;
    PlayerSpawn pSpawn;
	public bool bleeding;
	public float bleedDmg;
    bool isGoingToDie = false;
	// Use this for initialization
	void Start () {
        pSpawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpawn>();
		if (gameObject.name == "EnemyGiant" || gameObject.name == "EnemyGiant(Clone)") {
			startHealth = 200;
		}
		if (gameObject.name == "Enemy" || gameObject.name == "Enemy(Clone)") {
			startHealth = 100;
		}
		if (gameObject.name == "RealEnemyMage" || gameObject.name == "RealEnemyMage(Clone)") {
			startHealth = 50;
		}
        currHealth = startHealth;
        enemySpawn = GameObject.FindGameObjectWithTag("enemymanager").GetComponent<EnemySpawn>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (currHealth <= 0)
        {
            isGoingToDie = true;
        }
		if (bleeding) {
			currHealth -= bleedDmg;
		}
        if (pSpawn.GetArenaState() == false)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
    private void LateUpdate()
    {
        if (IsDead())
        {
			enemySpawn.IncreaseKillCount ();
			enemySpawn.DecreaseEnemiesInArena ();
			GameObject.Destroy(this.gameObject);
        }
    }
	public void TakeDamage(float dmg){
        if (currHealth - dmg <= 0)
            isGoingToDie = true;
        currHealth -= dmg;
	}
    public float GetHealth()
    {
        return currHealth;
    }
    public bool IsDead()
    {
        if (isGoingToDie) return true;
        return currHealth <= 0;
    }
}
