﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {
    [SerializeField]
    float timer;
    float timeBeforeDeletion;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        timeBeforeDeletion = 7f;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(500f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
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