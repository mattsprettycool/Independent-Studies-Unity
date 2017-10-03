using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageRadius : MonoBehaviour {
    EnemyMageAttack ema;
	// Use this for initialization
	void Start () {
        ema = gameObject.GetComponentInParent<EnemyMageAttack>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ema.SetInRange(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ema.SetInRange(false);
        }
    }
}
