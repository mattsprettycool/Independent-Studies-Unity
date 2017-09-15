using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellPickup : MonoBehaviour {
    [SerializeField]
    public GameObject prefabToCopy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(Camera.main.transform);
	}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
