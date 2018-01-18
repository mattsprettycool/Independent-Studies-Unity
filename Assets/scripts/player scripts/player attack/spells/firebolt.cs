using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class firebolt : MonoBehaviour {
    float timer;
    Vector3 storedVel;
    float timeBeforeDeletion;
	string debug;
    public GameObject explosion;
    //bool hitSomething;
    Rigidbody rb;
    [SerializeField]
    Vector3 directionToMove;
    ArtificialTimeManager realTime;
    // Use this for initialization
    void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        timer = 0;
        timeBeforeDeletion = 1000f;
        rb = gameObject.GetComponent<Rigidbody>();
        if(directionToMove.x > 0)
        {
            rb.AddRelativeForce(new Vector3(1000f, 0f, 0f));
        }else if (directionToMove.y > 0)
        {
            rb.AddRelativeForce(new Vector3(0f, 1000f, 0f));
        }
        else if (directionToMove.z > 0)
        {
            rb.AddRelativeForce(new Vector3(0f, 0f, 1000f));
        }


    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (realTime.IsTimeOn())
        {
            if(rb.velocity == Vector3.zero)
            {
                rb.velocity = storedVel;
            }
            if (timer >= timeBeforeDeletion)
            {
                GameObject.Destroy(gameObject);
            }
            timer += Time.deltaTime;
        }
        else
        {
            if(rb.velocity!=Vector3.zero)
                storedVel = rb.velocity;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        bool ignoreList = col.tag != "Player" && col.tag != "attacks" && col.name != "ProjectileSpawn" && col.tag != "ignoredByFB";
        bool destroyList = col.tag == "Enemies" || col.tag == "Floor" || col.tag == "Wall";
        if (ignoreList&&destroyList&& realTime.IsTimeOn())
        {
            if (explosion != null)
            {
                var attkInst = Instantiate(explosion);
                attkInst.transform.parent = gameObject.transform;
                attkInst.transform.localPosition = new Vector3(0f, 0f, 0f);
                attkInst.transform.SetParent(null);
            }
            GameObject.Destroy(this.gameObject);
        }
		if (col.tag == "Enemies"&& realTime.IsTimeOn())
		{
			try
			{
				col.GetComponent<EnemyHealth>().TakeDamage(gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit);
			}
			catch (Exception e)
			{
				debug += "\n" + e;
			}
		}
    }
    //public bool GetHit ()
    //{
        //return hitSomething;
    //}
}
