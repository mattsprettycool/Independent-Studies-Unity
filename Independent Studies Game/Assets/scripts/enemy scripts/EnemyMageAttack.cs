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
	public GameObject enemyFirebolt;
	public Transform fireboltSpawn;
	PlayerHealth playerHealth;
    EnemyMageProjectile emp;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		dmgPerAttk = 5;
		timeBetweenAttk = 1;
		inRange = false;
        emp = gameObject.GetComponentInChildren<EnemyMageProjectile>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        timer += Time.deltaTime;

        //if the time on the timer > .5 and player and enemy are colliding, enemy attacks player
        if (timer >= timeBetweenAttk && inRange)
        {
            emp.AttackPlayerRanged(enemyFirebolt);
            timer = 0;
        }
    }
	
    public void SetInRage(bool valToSet)
    {
        inRange = valToSet;
    }
}