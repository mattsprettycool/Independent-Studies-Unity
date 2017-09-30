using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//by Jai Saka
public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    public int startHealth;
    public int currHealth;
    float timer;
    NavMeshAgent agent;
    public EnemySpawn enemySpawn;
    string debug;
	// Use this for initialization
	void Start () {
        startHealth = 100;
        currHealth = startHealth;
        enemySpawn = GameObject.FindGameObjectWithTag("enemymanager").GetComponent<EnemySpawn>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        debug = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (currHealth <= 0)
        {
            enemySpawn.enemiesKilled++;
            GameObject.Destroy(this.gameObject);
        }
	}


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "projectiles")
        {
            try
            {
                currHealth -= collision.gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit;
            }
            catch (Exception e)
            {
                debug += "\n" + e;
            }
        }
    }
}
