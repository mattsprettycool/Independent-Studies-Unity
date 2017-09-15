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
    string debug;
	// Use this for initialization
	void Start () {
        startHealth = 100;
        currHealth = startHealth;
        agent = GetComponent<NavMeshAgent>();
        debug = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (currHealth <= 0)
        {
            agent.speed = 0;
            timer += Time.deltaTime;

            if (timer >= 2.5f)
            {
                GameObject.Destroy(this.gameObject);
            }

        }
	}


    private void OnCollisionEnter(Collision collision)
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
