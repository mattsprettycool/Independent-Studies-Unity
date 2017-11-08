using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class firebolt : MonoBehaviour {
    float timer;
    float timeBeforeDeletion;
	string debug;
    Rigidbody rb;
    [SerializeField]
    Vector3 directionToMove;
    // Use this for initialization
    void Start () {
        timer = 0;
        timeBeforeDeletion = 5.5f;
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
        
        if (timer >= timeBeforeDeletion)
        {
            GameObject.Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col)
    {
        bool ignoreList = col.tag != "Player" && col.tag != "attacks" && col.name != "ProjectileSpawn" && col.tag != "ignoredByFB";
        bool destroyList = col.tag == "Enemies" || col.tag == "Floor" || col.tag == "Wall";
        if (ignoreList&&destroyList)
        {
            GameObject.Destroy(gameObject);
        }
		if (col.tag == "Enemies")
		{
			try
			{
				col.GetComponent<EnemyHealth>().TakeDamage(gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit * (1 - (gameObject.GetComponent<ProjectileDamageLibrary>().travelTime * .01f)));
				col.GetComponent<EnemyHealth>().bleeding = true;
				col.GetComponent<EnemyHealth>().bleedDmg = gameObject.GetComponent<ProjectileDamageLibrary>().bleedDamage;
			}
			catch (Exception e)
			{
				debug += "\n" + e;
			}
		}
    }
}
