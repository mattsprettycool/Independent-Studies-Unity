using System.Collections;
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
	PlayerStamina playerStamina;
    bool keyTest;
    public spellPickup sp;
    public HealthPickup hp;
    [SerializeField]
    public bool doCommunicate;
    [SerializeField]
    public GameObject recentPickUp;
    // Use this for initialization
    void Start () {
		playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 20;
        maxVelocity = 20;
        maxVelSquared = maxVelocity * maxVelocity;
        jumpTest = false;
        doCommunicate = false;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "loot")
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
