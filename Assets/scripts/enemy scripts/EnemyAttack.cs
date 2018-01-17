using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public float dmgPerAttk;
	public float timeBetweenAttk;
	float timer;
	bool inRange;
	GameObject player;
	PlayerHealth playerHealth;
    ArtificialTimeManager realTime;
	// Use this for initialization
	void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        timer = 0;
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		dmgPerAttk = 10;
		timeBetweenAttk = 1f;
		inRange = false;
	}
    void FixedUpdate()
    {
        if (realTime.IsTimeOn())
        {
            timer += Time.deltaTime;
            if (inRange && timer > timeBetweenAttk && !playerHealth.GetBlocking())
            {
                timer = 0;
                playerHealth.TakeDamage(dmgPerAttk);
            }
        }
    }
    void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"&&realTime.IsTimeOn()) {
            inRange = true;
		}
	}
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"&&realTime.IsTimeOn())
        {
            inRange = false;
        }
    }
}