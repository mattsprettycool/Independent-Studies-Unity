using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        LookAtCenter();
		if (Input.GetMouseButtonUp(0))
        {
            //InstantiateStone();
        }
	}

    /*private void InstantiateStone()
    {
        var instAttk = Instantiate();
        instAttk.transform.parent = gameObject.transform;
        instAttk.transform.localPosition = new Vector3(0f, 0f, 0f);
        instAttk.transform.rotation = gameObject.transform.rotation;
        instAttk.transform.localRotation = Quaternion.Euler(0, -90, 0);
        instAttk.transform.localPosition = new Vector3(0f, 0f, 0);
        instAttk.transform.SetParent(null);
    }*/
    void LookAtCenter()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hit, 1000))
        {
            transform.LookAt(hit.point);
        }
    }
}
