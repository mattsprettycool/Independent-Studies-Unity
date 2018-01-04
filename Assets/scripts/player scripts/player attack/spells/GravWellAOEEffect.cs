using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GravWellAOEEffect : MonoBehaviour {
    string debug = "";
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemies")
        {
            NavMeshAgent navy = col.gameObject.GetComponent<NavMeshAgent>();
            //navy.velocity = new Vector3(navy.velocity.x, navy.velocity.y + 10, navy.velocity.z);
            navy.Warp(new Vector3(navy.gameObject.transform.position.x, navy.gameObject.transform.position.y + 1, navy.transform.position.z));
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemies")
        {
            NavMeshAgent navy = col.gameObject.GetComponent<NavMeshAgent>();
            navy.Warp(new Vector3(navy.gameObject.transform.position.x, navy.gameObject.transform.position.y + 1, navy.transform.position.z));
        }
    }
}
