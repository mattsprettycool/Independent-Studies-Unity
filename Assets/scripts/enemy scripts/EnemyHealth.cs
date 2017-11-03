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
	public bool bleeding;
	public float bleedDmg;
    string debug;
    bool isGoingToDie = false;
	// Use this for initialization
	void Start () {
        startHealth = 100;
        currHealth = startHealth;
        enemySpawn = GameObject.FindGameObjectWithTag("enemymanager").GetComponent<EnemySpawn>();
        debug = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (currHealth <= 0)
        {
            enemySpawn.enemiesKilled++;
            isGoingToDie = true;
        }
		if (bleeding) {
			currHealth -= bleedDmg;
		}
	}
    private void LateUpdate()
    {
        if(IsDead())
            GameObject.Destroy(this.gameObject);
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
