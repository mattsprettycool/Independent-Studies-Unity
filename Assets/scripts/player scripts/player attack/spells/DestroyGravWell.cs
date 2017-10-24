using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGravWell : MonoBehaviour {
    [SerializeField]
    int ttk = 250;
    bool aboutToDestroy = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ttk <= 0) Destroy(gameObject);
        ttk--;
        if (ttk - 1 <= 0)
            aboutToDestroy = true;
	}
    public bool IsAboutToDestroy()
    {
        return aboutToDestroy;
    }
}
