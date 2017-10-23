using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GravWellAOEEffect : MonoBehaviour {
    float oldY = 0;
    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Enemies")
        {
            if (col.gameObject.GetComponent<NavMeshAgent>().updatePosition)
            {
                col.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
                oldY = col.gameObject.GetComponent<Transform>().position.y;
            }
            Transform transPos = col.gameObject.GetComponent<Transform>();
            col.gameObject.GetComponent<Transform>().position = new Vector3(transPos.position.x, oldY + 5, transPos.position.z);
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
            Transform transPos = col.gameObject.GetComponent<Transform>();
            col.gameObject.GetComponent<Transform>().position = new Vector3(transPos.position.x, oldY + 10, transPos.position.z);
        }
    }
}
