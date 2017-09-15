using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//by Jai Saka
public class EnemyMovement : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    public Transform player;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        speed = 2.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        agent.SetDestination(player.position);

	}
}
