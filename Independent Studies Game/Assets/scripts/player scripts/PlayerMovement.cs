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
    bool keyTest;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 15;
        maxVelocity = 15;
        maxVelSquared = maxVelocity * maxVelocity;
        jumpTest = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Added this vvv
        if (rb.velocity.sqrMagnitude > maxVelSquared)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        if (Input.GetKey(KeyCode.W)&&jumpTest)
        {
            rb.AddRelativeForce(new Vector3(speed, 0, 0));
        }else if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(speed/2, 0, 0));
        }
        if (Input.GetKey(KeyCode.A) && jumpTest)
        {
            rb.AddRelativeForce(new Vector3(0, 0, speed));
        }else if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(new Vector3(0, 0, speed/2));
        }
        if (Input.GetKey(KeyCode.S) && jumpTest)
        {
            rb.AddRelativeForce(new Vector3(-speed, 0, 0));
        }else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(-speed/2, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) && jumpTest)
        {
            rb.AddRelativeForce(new Vector3(0, 0, -speed));
        }else if (Input.GetKey(KeyCode.D))
        {
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
    }
}
