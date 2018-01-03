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
    //CharacterController cont;
    // Use this for initialization
    void Start() {
        playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
        rb = gameObject.GetComponent<Rigidbody>();
		speed = .2f;
        jumpTest = false;
        doCommunicate = false;
		stunned = false;
        //cont = gameObject.GetComponent<CharacterController>();
        iBar = GameObject.FindGameObjectWithTag("ItemBarHolder").GetComponent<ItemBar>();
        iScreen = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>();
        pog = gameObject.GetComponentInChildren<PlayerOnGround>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, (transform.right+transform.forward)/2);
        bool pressW = Input.GetKey(KeyCode.W) && CanW();
        bool pressA = Input.GetKey(KeyCode.A) && CanA();
        bool pressS = Input.GetKey(KeyCode.S) && CanS();
        bool pressD = Input.GetKey(KeyCode.D) && CanD();
        float x = 0, z = 0, negX = 0, negZ = 0;
        if (stunned)
        {
            stunned = false;
        }
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && playerStamina.currStamina >=.5f&& pressW && !stunned)
        {
                z = 2f;
                playerStamina.currStamina -= .5f;
            
        }
        else{
            if (pressW && !stunned)
            {
                z = 1;
            }
			if (pressS && !stunned)
            {
                negZ = -1;
            }
			if (pressA && !stunned)
            {
                x = 1;
            }
			if (pressD && !stunned)
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
            gameObject.transform.Translate(new Vector3(z * speed, y * speed * .25f, x * speed));
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
    bool CanW()
    {
        return RayW()&&RayWD()&&RayAW();
    }
    bool CanA()
    {
        return RayA()&&RayAS()&&RayAW();
    }
    bool CanS()
    {
        return RayS()&&RayAS()&&RaySD();
    }
    bool CanD()
    {
        return RayD()&&RaySD()&&RayWD();
    }

    bool RayW()
    {
        RaycastHit hitinfo;
        
        if(Physics.Raycast(gameObject.transform.position, gameObject.transform.right, out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
    bool RayWD()
    {
        RaycastHit hitinfo;

        if (Physics.Raycast(gameObject.transform.position, (gameObject.transform.right-transform.forward)/2, out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
    bool RayD()
    {
        RaycastHit hitinfo;

        if (Physics.Raycast(gameObject.transform.position, -gameObject.transform.forward, out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
    bool RaySD()
    {
        RaycastHit hitinfo;

        if (Physics.Raycast(gameObject.transform.position, (-gameObject.transform.right-transform.forward)/2, out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
    bool RayS()
    {
        RaycastHit hitinfo;

        if (Physics.Raycast(gameObject.transform.position, -gameObject.transform.right, out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
    bool RayAS()
    {
        RaycastHit hitinfo;

        if (Physics.Raycast(gameObject.transform.position, (gameObject.transform.forward-transform.right), out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
    bool RayA()
    {
        RaycastHit hitinfo;

        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
    bool RayAW()
    {
        RaycastHit hitinfo;

        if (Physics.Raycast(gameObject.transform.position, (gameObject.transform.forward+transform.right)/2, out hitinfo, .75f, 1 << 8))
        {
            if (hitinfo.collider.tag.Equals("Wall"))
                return false;
        }
        return true;
    }
}
