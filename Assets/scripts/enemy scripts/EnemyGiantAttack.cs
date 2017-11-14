using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGiantAttack : MonoBehaviour {
	public float dmgPerAttk;
	public float timeBetweenAttk;
	float timer;
	bool inRange;
	GameObject player;
	PlayerHealth playerHealth;
	PlayerMovement plyrMov;
	Rigidbody plyrRB;
	// Use this for initialization
	void Start () {
		timer = 0;
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		plyrMov = player.GetComponent<PlayerMovement> ();
		plyrRB = player.GetComponent<Rigidbody> ();
		dmgPerAttk = 20;
		timeBetweenAttk = 4f;
		inRange = false;
	}
	void FixedUpdate()
	{
		timer += Time.deltaTime;
		if (inRange && timer > timeBetweenAttk)
		{
			timer = 0;
			int randy = Random.Range (0, 3);
			Debug.Log (randy);
			switch (randy) {
			case 0:
				playerHealth.TakeDamage (dmgPerAttk);
				break;
			case 1:
                plyrMov.stunned = true;
				playerHealth.TakeDamage (dmgPerAttk / 2);
				break;
			case 2:
				plyrRB.AddRelativeForce (0, 2000, 0);
				playerHealth.TakeDamage (dmgPerAttk);
				break;
			default:
				break;
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			inRange = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			inRange = false;
		}
	}
}
