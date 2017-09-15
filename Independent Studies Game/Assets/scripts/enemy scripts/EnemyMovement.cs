using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//by Jai Saka
public class EnemyMovement : MonoBehaviour {
	public Transform player;
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (player.position);
	}
}
