using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrallAttack : MonoBehaviour {
	public GameObject enemyExplosion;
	GameObject player;
	EnemySpawn enSpawn;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enSpawn = GameObject.FindGameObjectWithTag ("enemymanager").GetComponent<EnemySpawn>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
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
