using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    [SerializeField]
    public GameObject firebolt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var attackInst = Instantiate(firebolt);
            attackInst.transform.parent = gameObject.transform;
            attackInst.transform.localPosition = new Vector3(0f, 0f, 0f);
            attackInst.transform.rotation = gameObject.transform.rotation;
            attackInst.transform.localRotation = Quaternion.Euler(0, 0, 0);
            attackInst.transform.localPosition = new Vector3(0f, 0f, 1f);
            attackInst.transform.SetParent(null);
        }
	}
}
