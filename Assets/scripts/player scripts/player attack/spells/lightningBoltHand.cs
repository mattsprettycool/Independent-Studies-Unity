using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningBoltHand : MonoBehaviour {
    lightningBolt lb;
    PlayerMana playerMana;
    // Use this for initialization
    void Start () {
        lb = GetComponentInParent<lightningBolt>();
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
            if (lb.HitSomething())
            {
                gameObject.transform.LookAt(lb.GetRaycastHit().point);
            }
    }
}
