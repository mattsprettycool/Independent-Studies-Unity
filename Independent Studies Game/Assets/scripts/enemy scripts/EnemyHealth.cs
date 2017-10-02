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
    NavMeshAgent agent;
    public EnemySpawn enemySpawn;
	public bool bleeding;
	public float bleedDmg;
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
		if (bleeding) {
			currHealth -= bleedDmg;
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
	public void TakeDamage(float dmg){
		currHealth -= dmg;
	}
}
