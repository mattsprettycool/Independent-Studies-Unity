using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSword : MonoBehaviour {
    [SerializeField]
    GameObject projectileToSpawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectileToSpawn, gameObject.transform.position, Camera.main.transform.rotation);
        }
	}
}
