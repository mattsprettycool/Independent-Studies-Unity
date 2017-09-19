using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyMageAttack : MonoBehaviour {
	[SerializeField]
	public int dmgPerAttk;
	public float timeBetweenAttk;
	float timer;
	int inLevel;
	bool inRange;
	bool touchingBody;
	GameObject player;
	public GameObject firebolt;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		dmgPerAttk = 5;
		timeBetweenAttk = .5f;
		inRange = false;
		touchingBody = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		timer += Time.deltaTime;

		//if the time on the timer > .5 and player and enemy are colliding, enemy attacks player
		if (timer >= timeBetweenAttk && inRange && inLevel == 1)
		{
			AttackPlayerRanged ();
		}
		if (timer >= timeBetweenAttk && inRange && inLevel == 2) {
			
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			inLevel++;
			inRange = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			inLevel--;
			inRange = false;
		} 
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject == player)
		{
			touchingBody = true;
		}
	}
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject == player)
		{
			touchingBody = false;
		} 
	}

	//resets timer so enemy can attack again and inflicts damage, calling upon the method TakeDamage in PlayerHealth.cs
	void AttackPlayer()
	{
		timer = 0;
		if (playerHealth.currHealth > 0 && touchingBody)
		{
			playerHealth.TakeDamage (dmgPerAttk * 2);
		}
		else if (playerHealth.currHealth > 0)
		{
			playerHealth.TakeDamage(dmgPerAttk);
		}
	}
	void AttackPlayerRanged ()
	{
		timer = 0;
		if (playerHealth.currHealth > 0) 
		{
			var attackInst = Instantiate(firebolt);
			attackInst.transform.parent = gameObject.transform;
			attackInst.transform.localPosition = new Vector3(0f, 0f, 0f);
			attackInst.transform.rotation = gameObject.transform.rotation;
			attackInst.transform.localRotation = Quaternion.Euler(0, -90, 0);
			attackInst.transform.localPosition = new Vector3(0f, 0f, .75f);
			attackInst.transform.SetParent(null);
		}
	}
}