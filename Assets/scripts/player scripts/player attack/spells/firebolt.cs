using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
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
	void FixedUpdate ()
    {
        
        if (timer >= timeBeforeDeletion)
        {
            GameObject.Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool ignoreList = other.tag != "Player" && other.tag != "attacks" && other.name != "ProjectileSpawn" && other.tag != "ignoredByFB";
        bool destroyList = other.tag == "Enemies" || other.tag == "Floor" || other.tag == "Wall";
        if (ignoreList&&destroyList)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
