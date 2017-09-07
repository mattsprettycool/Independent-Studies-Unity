using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By Matt Braden
public class PlayerMovement : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    [SerializeField]
    bool jumpTest;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 15;
        jumpTest = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, 0, speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, -speed));
        }
        if (Input.GetKeyDown(KeyCode.Space)&&jumpTest)
        {
            rb.AddForce(new Vector3(0, 300, 0));
            jumpTest = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Floor") jumpTest = true;
    }
}
