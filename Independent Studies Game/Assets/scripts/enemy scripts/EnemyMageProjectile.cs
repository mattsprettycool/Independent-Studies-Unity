using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AttackPlayerRanged(GameObject enemyFirebolt)
    {
        Instantiate(enemyFirebolt, gameObject.transform.position, gameObject.transform.localRotation);
    }
}
