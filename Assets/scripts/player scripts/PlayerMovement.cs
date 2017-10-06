﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class PlayerMovement : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    [SerializeField]
    bool jumpTest;
    float maxVelocity;
    float maxVelSquared;
    public GameObject cameraLoc;
	//PlayerStamina playerStamina;
    bool keyTest;
    public spellPickup sp;
    public HealthPickup hp;
    [SerializeField]
    public bool doCommunicate;
    [SerializeField]
    public GameObject recentPickUp;
    ItemBar iBar;
    InventoryScreen iScreen;
    // Use this for initialization
    void Start () {
		//playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 20;
        maxVelocity = 20;
        maxVelSquared = maxVelocity * maxVelocity;
        jumpTest = false;
        doCommunicate = false;
        iBar = Camera.main.GetComponent<ItemBar>();
        iScreen = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Added this vvv
		if (rb.velocity.sqrMagnitude > maxVelSquared)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
			
		if (Input.GetKey(KeyCode.W)&&jumpTest)
        {
            if(rb.velocity.x < 0)
                rb.AddRelativeForce(new Vector3(rb.velocity.x*-1, 0, 0));
            rb.AddRelativeForce(new Vector3(speed, 0, 0));
        }else if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.x < 0)
                rb.AddRelativeForce(new Vector3(rb.velocity.x * -1, 0, 0));
            rb.AddRelativeForce(new Vector3(speed/2, 0, 0));
        }
        if (Input.GetKey(KeyCode.A) && jumpTest)
        {
            if (rb.velocity.z < 0)
                rb.AddRelativeForce(new Vector3(0, 0, rb.velocity.z * -1));
            rb.AddRelativeForce(new Vector3(0, 0, speed));
        }else if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.z < 0)
                rb.AddRelativeForce(new Vector3(0, 0, rb.velocity.z * -1));
            rb.AddRelativeForce(new Vector3(0, 0, speed/2));
        }
        if (Input.GetKey(KeyCode.S) && jumpTest)
        {
            if (rb.velocity.x > 0)
                rb.AddRelativeForce(new Vector3(rb.velocity.x, 0, 0));
            rb.AddRelativeForce(new Vector3(-speed, 0, 0));
        }else if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.x > 0)
                rb.AddRelativeForce(new Vector3(rb.velocity.x, 0, 0));
            rb.AddRelativeForce(new Vector3(-speed/2, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) && jumpTest)
        {
            if (rb.velocity.z > 0)
                rb.AddRelativeForce(new Vector3(0, 0, rb.velocity.z));
            rb.AddRelativeForce(new Vector3(0, 0, -speed));
        }else if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.z > 0)
                rb.AddRelativeForce(new Vector3(0, 0, rb.velocity.z));
            rb.AddRelativeForce(new Vector3(0, 0, -speed/2));
        }
		if (Input.GetKeyDown(KeyCode.Space)&&jumpTest)
        {
            rb.AddRelativeForce(new Vector3(0, 300, 0));
            jumpTest = false;
        }
        Camera.main.transform.position = cameraLoc.transform.position;
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Floor") jumpTest = true;
        if (col.collider.tag == "Wall") rb.velocity = Vector3.zero;
    }
    void OnCollisionStay(Collision col)
    {
        if (col.collider.tag == "Floor") jumpTest = true;
        if (col.collider.tag == "Wall") rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "loot" && !iScreen.IsFull())
        {
            sp = other.gameObject.GetComponent(typeof(spellPickup)) as spellPickup;
            doCommunicate = true;
            recentPickUp = sp.prefabToCopy;
        }
        if (other.tag == "loot" && !iBar.IsFull())
        {
            sp = other.gameObject.GetComponent(typeof(spellPickup)) as spellPickup;
            doCommunicate = true;
            recentPickUp = sp.prefabToCopy;
        }
    }
    public void setCommToFalse()
    {
        doCommunicate = false;
    }
}
