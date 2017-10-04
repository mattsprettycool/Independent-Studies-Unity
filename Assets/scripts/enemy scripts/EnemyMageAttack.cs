using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyMageAttack : MonoBehaviour {
	[SerializeField]
	public int dmgPerAttk;
	public float timeBetweenAttk;
	public float timer, turnSpeed;
	public bool inRange;
	GameObject player;
    public Transform enFireBoltSpawn;
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
		Vector3 dir = (player.gameObject.transform.position - transform.position).normalized;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), Time.deltaTime * turnSpeed);
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttk && inRange)
        {
            Debug.Log("Firing");
            Instantiate(enemyFirebolt, enFireBoltSpawn.position, gameObject.transform.rotation);
            timer = 0;
            
        }
    }

	public void SetInRange(bool boo1){
		inRange = boo1;
	}
}