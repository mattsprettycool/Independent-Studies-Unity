using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GravWellAOEEffect : MonoBehaviour {
    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Enemies")
        {
            col.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
            col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemies")
        {
            col.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
            col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        }
    }
}
