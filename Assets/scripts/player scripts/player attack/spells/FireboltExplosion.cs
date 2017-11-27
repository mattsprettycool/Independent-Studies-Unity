using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltExplosion : MonoBehaviour {
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<ParticleSystem>().Play();
		GameObject.Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().main.duration);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(10);
        }
    }
}
