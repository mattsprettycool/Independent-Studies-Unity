using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageProjectile : MonoBehaviour {
    public Transform player;
    Vector3 dir;
    float turnSpeed;
    Quaternion quat;
    // Use this for initialization
    void Start () {
        dir = new Vector3(0, 0, 0);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        turnSpeed = 10;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        quat = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y + 90, gameObject.transform.rotation.z, 0);
        Vector3 dir = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), Time.deltaTime * turnSpeed);
    }
    public void AttackPlayerRanged(GameObject enemyFirebolt)
    {
        Instantiate(enemyFirebolt, gameObject.transform.position, quat);
    }
}
