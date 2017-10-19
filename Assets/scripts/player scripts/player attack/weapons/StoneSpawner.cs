using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour {
	public StoneScript stone;
	public SlingMovement sling;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (Input.GetMouseButtonUp(0))
        {
			LookAtCenter();
            InstantiateStone();
        }
	}

    private void InstantiateStone()
    {
        var instAttk = Instantiate(stone);
        instAttk.transform.parent = gameObject.transform;
        instAttk.transform.localPosition = new Vector3(0f, 0f, 0f);
        instAttk.transform.rotation = gameObject.transform.rotation;
        instAttk.transform.localRotation = Quaternion.Euler(0, -90, 0);
        instAttk.transform.localPosition = new Vector3(0f, .5f, 0);
        instAttk.transform.SetParent(null);
    }
    void LookAtCenter()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hit, 1000, 1 << 8))
        {
            transform.LookAt(hit.point);
        }
		else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hit, 1000, 1 << 9))
		{
			transform.LookAt(hit.point);
		}
    }
}
