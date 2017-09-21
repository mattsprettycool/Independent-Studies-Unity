using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyMageAttack : MonoBehaviour {
	[SerializeField]
	public int dmgPerAttk;
	public float timeBetweenAttk;
	float timer;
	bool inRange;
	GameObject player;
	public Transform fireboltSpawn;
	public GameObject enemyFirebolt;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		dmgPerAttk = 5;
		timeBetweenAttk = 1;
		inRange = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		timer += Time.deltaTime;

		//if the time on the timer > .5 and player and enemy are colliding, enemy attacks player
		if (timer >= timeBetweenAttk && inRange) 
		{
			AttackPlayerRanged ();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			inRange = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			inRange = false;
		} 
	}
	void AttackPlayerRanged ()
	{
		timer = 0;
		var attkInst = Instantiate(enemyFirebolt);
		attkInst.transform.parent = fireboltSpawn;
		attkInst.transform.localPosition = fireboltSpawn.position;
		attkInst.transform.rotation = fireboltSpawn.rotation;
		attkInst.transform.localRotation = Quaternion.Euler(0, -90, 0);
		attkInst.transform.localPosition = new Vector3(0f, 0f, .75f);
		attkInst.transform.SetParent(null);
	}
}