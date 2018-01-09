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
            navy.isStopped = true;
        }
    }
}
