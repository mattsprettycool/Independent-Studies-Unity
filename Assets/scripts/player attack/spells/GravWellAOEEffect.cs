using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GravWellAOEEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemies")
        {
            col.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
            col.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up*10, ForceMode.Impulse);
            //col.gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
        }
    }
}
