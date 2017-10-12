using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnDeath : MonoBehaviour {
    [SerializeField]
    public GameObject particles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<EnemyHealth>().IsDead())
            Instantiate(particles, gameObject.transform.position, particles.transform.rotation);
	}
}
