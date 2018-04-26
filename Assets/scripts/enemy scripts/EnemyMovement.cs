using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
//by Jai Saka
public class EnemyMovement : MonoBehaviour {
	public Transform player;
    ArtificialTimeManager realTime;
	NavMeshAgent agent;
    string bugLog;
	Quaternion quat;
    bool isStoppedExternally = false;
    //DestroyGravWell dgw;
	// Use this for initialization
	void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent = gameObject.GetComponent<NavMeshAgent> ();
        bugLog = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!realTime.IsTimeOn())
        {
            agent.isStopped = true;
            agent.updatePosition = false;
        }
        else
        {
            if (!isStoppedExternally)
            {
                agent.isStopped = false;
                agent.updatePosition = true;
            }
            else
            {
                agent.isStopped = true;
                agent.updatePosition = false;
            }
        }
        if (agent.updatePosition && realTime.IsTimeOn())
        {
            try
            {
                agent.SetDestination(player.position);
            }
            catch (Exception e)
            {
                bugLog += e;
            }
        }
        //if (!agent.updatePosition) agent.isStopped = true;
    }
    public void SetStopped(bool b)
    {
        isStoppedExternally = b;
    }
}
