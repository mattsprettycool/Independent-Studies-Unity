using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebolt : MonoBehaviour {
    float timer;
    float timeBeforeDeletion;
    // Use this for initialization
    void Start () {
        timer = 0;
        timeBeforeDeletion = 5;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timer >= timeBeforeDeletion)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
