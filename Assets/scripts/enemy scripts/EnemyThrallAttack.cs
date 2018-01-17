using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrallAttack : MonoBehaviour {
	public GameObject enemyExplosion;
	GameObject player;
	EnemySpawn enSpawn;
    ArtificialTimeManager realTime;
	// Use this for initialization
	void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        player = GameObject.FindGameObjectWithTag ("Player");
		enSpawn = GameObject.FindGameObjectWithTag ("enemymanager").GetComponent<EnemySpawn>();
	}
	

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"&&realTime.IsTimeOn()) {
			var attackInst = Instantiate (enemyExplosion);
			attackInst.transform.parent = gameObject.transform;
			attackInst.transform.localPosition = new Vector3 (0, 0, 0);
			attackInst.transform.SetParent (null);
			player.transform.GetComponent<Rigidbody> ().AddExplosionForce (750, gameObject.transform.position, 100, 100);
			enSpawn.enemiesInArena--;
			GameObject.Destroy (gameObject);
		}
	}
}
