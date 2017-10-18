using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningBoltHand : MonoBehaviour {
    lightningBolt lb;
    PlayerMana playerMana;
    [SerializeField]
    GameObject particles;
    bool firstTime = true;
    // Use this for initialization
    void Start () {
        lb = GetComponentInParent<lightningBolt>();
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
            if (lb.HitSomething())
            {
                gameObject.transform.LookAt(lb.GetRaycastHit().point);
            }
        if (lb.IsShooting() && Input.GetKey(KeyCode.Mouse0) && playerMana.currMana >= 5 && Time.timeScale == 1f)
        {
            if(firstTime)
            Instantiate(particles, GameObject.FindGameObjectWithTag("lightningPointer").transform.position, GameObject.FindGameObjectWithTag("lightningPointer").transform.rotation, gameObject.transform);
            firstTime = false;
        }
        else
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("lightning"))
                Destroy(obj);
            firstTime = true;
        }
    }
}
