using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyMageAttack : MonoBehaviour {
	[SerializeField]
	public int dmgPerAttk;
	public float timeBetweenAttk;
	float timer, turnSpeed;
	bool inRange;
	GameObject player;
	Quaternion quat;
	public GameObject enemyFirebolt;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		dmgPerAttk = 5;
		timeBetweenAttk = 2;
		inRange = false;
		turnSpeed = 10;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		quat = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0);
		Vector3 dir = (player.gameObject.transform.position - transform.position).normalized;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), Time.deltaTime * turnSpeed);
        timer += Time.deltaTime;

        //if the time on the timer > .5 and player and enemy are colliding, enemy attacks player
        if (timer >= timeBetweenAttk && inRange)
        {
			Instantiate(enemyFirebolt, gameObject.transform.position, quat);
            timer = 0;
        }
    }

	public void SetInRange(bool boo){
		inRange = boo;
	}
}