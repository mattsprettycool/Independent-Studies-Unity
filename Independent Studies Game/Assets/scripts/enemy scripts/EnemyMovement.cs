using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
//by Jai Saka
public class EnemyMovement : MonoBehaviour {
	public Transform player;
	NavMeshAgent agent;
    String bugLog;
    float turnSpeed;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent = gameObject.GetComponent<NavMeshAgent> ();
        bugLog = "";
        turnSpeed = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), Time.deltaTime * turnSpeed);
        try
        {
            agent.SetDestination(player.position);
        }
        catch (Exception e)
        {
            bugLog += e;
        }
        if (!agent.updatePosition) agent.isStopped = true;
	}
    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            if (!agent.updatePosition && collision.collider.tag == "Floor")
            {
                agent.updatePosition = true;
                agent.isStopped = false;
            }
        }catch(Exception e)
        {
            bugLog += e;
        }
    }
}
