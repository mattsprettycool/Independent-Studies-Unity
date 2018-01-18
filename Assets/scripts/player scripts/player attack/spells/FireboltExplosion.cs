using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltExplosion : MonoBehaviour {
	PlayerHealth pHealth;
	float timer;
    ArtificialTimeManager realTime;
	// Use this for initialization
	void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
		timer = 0;
		pHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth>();
        gameObject.GetComponent<ParticleSystem>().Play();
    }
	void FixedUpdate()
	{
        if (realTime.IsTimeOn())
        {
            timer += Time.deltaTime;
            if (timer > 1000)
            {
                GameObject.Destroy(gameObject);
            }
        }
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && gameObject.name == "EnemyExplosion(Clone)" && realTime.IsTimeOn()) 
		{
			pHealth.TakeDamage (25);
		}
	}
}
