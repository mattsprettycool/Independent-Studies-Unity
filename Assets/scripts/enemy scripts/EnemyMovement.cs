using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
//by Jai Saka
public class EnemyMovement : MonoBehaviour {
	public Transform player;
	NavMeshAgent agent;
    string bugLog;
	Quaternion quat;
    //DestroyGravWell dgw;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent = gameObject.GetComponent<NavMeshAgent> ();
        bugLog = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        agent.isStopped = false;
		if(agent.updatePosition)
        try
        {
            agent.SetDestination(player.position);
        }
        catch (Exception e)
        {
            bugLog += e;
        }
        //if (!agent.updatePosition) agent.isStopped = true;
	}
   // private void OnCollisionEnter(Collision collision)
    //{
       // try
     //   {
      //      if (!agent.updatePosition && collision.collider.tag == "Floor")
       //     {
        //        agent.updatePosition = true;
       //         agent.isStopped = false;
        //    }else if (dgw.IsAboutToDestroy())
       //     {
         //       agent.updatePosition = true;
        //        agent.isStopped = false;
       //     }
      //  }catch(Exception e)
    //    {
     //       agent.updatePosition = true;
    //        agent.isStopped = false;
      //      bugLog += e;
     //   }
   // }
}
