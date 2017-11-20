using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class PlayerMovement : MonoBehaviour {
    Rigidbody rb;
    public float speed;
	public bool stunned;
    [SerializeField]
    bool jumpTest;
    public GameObject cameraLoc;
    PlayerStamina playerStamina;
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
    PlayerOnGround pog;
    bool canDoubleJump = true;
	PlayerStats pStats;
    //CharacterController cont;
    // Use this for initialization
    void Start() {
        playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
        rb = gameObject.GetComponent<Rigidbody>();
		pStats = gameObject.GetComponent<PlayerStats> ();
		speed = pStats.baseMovementSpeed;
        jumpTest = false;
        doCommunicate = false;
		stunned = false;
        //cont = gameObject.GetComponent<CharacterController>();
        iBar = Camera.main.GetComponent<ItemBar>();
        iScreen = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>();
        pog = gameObject.GetComponentInChildren<PlayerOnGround>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = 0, z = 0, negX = 0, negZ = 0;
        if (stunned)
        {
            stunned = false;
        }
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && playerStamina.currStamina >=.5f&& Input.GetKey(KeyCode.W) && !stunned)
        {
                z = 2f;
                playerStamina.currStamina -= .5f;
            
        }
        else{
            if (Input.GetKey(KeyCode.W) && !stunned)
            {
                z = 1;
            }
			if (Input.GetKey(KeyCode.S) && !stunned)
            {
                negZ = -1;
            }
			if (Input.GetKey(KeyCode.A) && !stunned)
            {
                x = 1;
            }
			if (Input.GetKey(KeyCode.D) && !stunned)
            {
                negX = -1;
            }
        }
        MoveFullSpeed(x + negX, 0, z + negZ);
        if (Input.GetKeyDown(KeyCode.Space) && (pog.IsOnGround()||canDoubleJump) && !stunned)
        {
            rb.AddRelativeForce(new Vector3(0, 300, 0));
            jumpTest = false;
            isNotInAir = false;
            canDoubleJump = false;
        }
        if (!canDoubleJump)
        {
            canDoubleJump = pog.IsOnGround();
        }
        CameraController();
    }
    void MoveFullSpeed(float x, float y, float z)
    {
        if (x!=0||y!=0||z!=0) 
		{
            gameObject.transform.Translate(new Vector3(z * speed, y * speed, x * speed));
			//rb.AddRelativeForce(new Vector3(speed * x, y, speed * z), ForceMode.Impulse);
        }
        else if(pog.IsOnGround())
        {
            rb.velocity = new Vector3(0,rb.velocity.y,0);
        }
    }
    void OnCollisionStay(Collision col)
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
		if (other.name == "JumpCube" || other.name == "JumpCube(clone)") {
			rb.AddRelativeForce (0, 1500, 0);
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
    public float GetSpeed()
    {
        return speed;
    }
    void CameraController()
    {
        CameraMovement cm = gameObject.gameObject.GetComponent<CameraMovement>();
        if (cm.IsInFirstPerson())
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Camera.main.transform.position = cameraLoc.transform.position;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Camera.main.transform.position = GameObject.FindGameObjectWithTag("3ps").transform.position;
        }
    }
}
