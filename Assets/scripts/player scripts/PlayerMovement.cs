using System.Collections;
using System.Linq;
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
    bool isNotInAir = true;
    bool startWait = false;
    //CharacterController cont;
    // Use this for initialization
    void Start() {
        //playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
        rb = gameObject.GetComponent<Rigidbody>();
        speed = .2f;
        maxVelocity = 20;
        maxVelSquared = maxVelocity * maxVelocity;
        jumpTest = false;
        doCommunicate = false;
        //cont = gameObject.GetComponent<CharacterController>();
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
            int x = 0, z = 0, negX = 0, negZ = 0;
            if (Input.GetKey(KeyCode.W))
            {
                z = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                negZ = -1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                x = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                negX = -1;
            }
            MoveFullSpeed(x + negX, 0, z + negZ);

        }
        else
        {
            float x = 0, z = 0, negX = 0, negZ = 0;
            if (Input.GetKey(KeyCode.W))
            {
                z = .5f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                negZ = -.5f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                x = .5f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                negX = -.5f;
            }
            MoveFullSpeed(x + negX, 0, z + negZ);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpTest)
        {
            //rb.AddRelativeForce(new Vector3(0, 300, 0));
            int i = 10;
            while (false)
            {
                bool notWentThrough = true;
                WaitTime(.01f);
                while (notWentThrough)
                {
                    if (startWait)
                    {
                        gameObject.transform.Translate(new Vector3(0, speed * i, 0));
                        notWentThrough = false;
                        startWait = false;
                        i--;
                    }
                }
            }
            jumpTest = false;
            isNotInAir = false;
        }
        Camera.main.transform.position = cameraLoc.transform.position;
    }
    void MoveFullSpeed(float x, float y, float z)
    {
        if (x!=0||y!=0||z!=0) 
		{
            gameObject.transform.Translate(new Vector3(z * speed, y * speed, x * speed));
			//rb.AddRelativeForce(new Vector3(speed * x, y, speed * z), ForceMode.Impulse);
        }
        else if(jumpTest)
        {
            //rb.velocity = new Vector3(0,rb.velocity.y,0);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Floor")
        {
            jumpTest = true;
            isNotInAir = true;
        }
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
    public bool IsInAir()
    {
        return !isNotInAir;
    }
    IEnumerator WaitTime(float seconds)
    {
        startWait = false;
        yield return new WaitForSeconds(seconds);
        startWait = true;
    }
}
