using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyAttack : MonoBehaviour {
    [SerializeField]
    public int dmgPerAttk;
    public float timeBetweenAttk;
    float timer;
    bool inRange;
	bool touchingBody;
    GameObject player;
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
		if (timer >= timeBetweenAttk && inRange)
        {
			AttackPlayer ();
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
}