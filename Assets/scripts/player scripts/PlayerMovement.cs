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
        speed = .5f;
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

        if (jumpTest)
        {
            rb.AddRelativeForce(new Vector3(speed * Input.GetAxis("Vertical"), 0, speed * Input.GetAxis("Horizontal") * -1),ForceMode.Impulse);
            
        }
        else
        {
            rb.AddRelativeForce(new Vector3((speed * Input.GetAxis("Vertical"))/2, 0, (speed * Input.GetAxis("Horizontal") * -1)/2));
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
    void OnCollisionStay(Collision col)
    {
        if (col.collider.tag == "Floor") jumpTest = true;
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
