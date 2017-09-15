using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebolt : MonoBehaviour {
    float timer;
    float timeBeforeDeletion;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        timer = 0;
        timeBeforeDeletion = 5.5f;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(1000f, 0f, 0f));
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
