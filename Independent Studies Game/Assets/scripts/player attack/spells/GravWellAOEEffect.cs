using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            col.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,100,0));
        }
    }
}
