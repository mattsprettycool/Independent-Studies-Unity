using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class Bolt : MonoBehaviour {
    [SerializeField]
    float timer;
    float timeBeforeDeletion;
    Rigidbody rb;
	string debug;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        timeBeforeDeletion = 7;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(375, 0, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (timer >= timeBeforeDeletion)
        {
            GameObject.Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
        gameObject.GetComponent<ProjectileDamageLibrary>().travelTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player" && col.tag != "attacks")
        {
            GameObject.Destroy(this.gameObject);
        }
		if (col.tag == "Enemies") {
			try {
                col.GetComponent<EnemyHealth>().TakeDamage(gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit);
				col.GetComponent<EnemyHealth> ().bleeding = true;
				col.GetComponent<EnemyHealth> ().bleedDmg = gameObject.GetComponent<ProjectileDamageLibrary> ().bleedDamage;
			}
			catch(Exception e){
				debug += "\n" + e;
			}
		}
    }
}
