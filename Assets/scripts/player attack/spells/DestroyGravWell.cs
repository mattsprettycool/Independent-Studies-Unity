using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGravWell : MonoBehaviour {
    [SerializeField]
    int ttk = 250;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ttk <= 0) Destroy(gameObject);
        ttk--;
	}
}
