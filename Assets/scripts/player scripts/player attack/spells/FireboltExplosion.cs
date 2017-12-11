using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltExplosion : MonoBehaviour {
	PlayerHealth pHealth;
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
		pHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth>();
        gameObject.GetComponent<ParticleSystem>().Play();
    }
	void FixedUpdate()
	{
		timer += Time.deltaTime;
		if (timer > gameObject.GetComponent<ParticleSystem> ().main.duration) 
		{
			GameObject.Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && gameObject.name == "EnemyExplosion(Clone)") 
		{
			pHealth.TakeDamage (25);
		}
	}
}
