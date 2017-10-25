using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GravWellAOEEffect : MonoBehaviour {
    float oldY = 0;
    string debug = "";
    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Enemies")
        {
            if (col.gameObject.GetComponent<NavMeshAgent>().updatePosition)
            {
                col.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
                oldY = col.gameObject.GetComponent<Transform>().position.y;
            }
            NavMeshAgent navy = col.gameObject.GetComponent<NavMeshAgent>();
            Transform transPos = col.gameObject.GetComponent<Transform>();
            navy.Warp(new Vector3(transPos.position.x, oldY + 2, transPos.position.z));
            try
            {
                
                if (gameObject.GetComponentInParent<DestroyGravWell>().IsAboutToDestroy())
                    col.gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
            }
            catch (System.Exception e)
            {
                debug += e;
                col.gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemies")
        {
            if (col.gameObject.GetComponent<NavMeshAgent>().updatePosition)
            {
                col.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
                oldY = col.gameObject.GetComponent<Transform>().position.y;
            }
            NavMeshAgent navy = col.gameObject.GetComponent<NavMeshAgent>();
            Transform transPos = col.gameObject.GetComponent<Transform>();
            navy.Warp(new Vector3(transPos.position.x, oldY + 2, transPos.position.z));
            try
            {
                if (gameObject.GetComponentInParent<DestroyGravWell>().IsAboutToDestroy())
                    col.gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
            }
            catch (System.Exception e)
            {
                debug += e;
                col.gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
            }
        }
    }
}
