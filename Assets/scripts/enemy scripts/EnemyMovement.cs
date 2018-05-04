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
    //Vector3 stopLoc = Vector3.zero;
    //bool justRestarted = false;
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
        try
        {
            if (!realTime.IsTimeOn())
            {
                //stopLoc = gameObject.transform.position;
                agent.isStopped = true;
                agent.updatePosition = false;
                //justRestarted = true;
                agent.enabled = false;
            }
            else
            {
                if (!isStoppedExternally)
                {
                    agent.enabled = true;
                    //stopLoc = gameObject.transform.position;
                    agent.isStopped = false;
                    agent.updatePosition = true;
                    //justRestarted = true;
                }
                else
                {
                    //if (justRestarted)
                    //{
                    //  gameObject.transform.position = stopLoc;
                    //}
                    agent.isStopped = true;
                    agent.updatePosition = false;
                    agent.enabled = false;
                }
            }
        }catch(Exception e)
        {
            bugLog += e;
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
