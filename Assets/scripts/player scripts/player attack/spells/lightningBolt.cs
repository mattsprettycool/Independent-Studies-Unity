using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningBolt : MonoBehaviour {
    PlayerMana playerMana;
    [SerializeField]
    float damage = 10f;
    int delay = 5;
    RaycastHit rch;
    bool hitSomething = false;
    bool isShooting = false;
    // Use this for initialization
    void Start () {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Mouse0) && playerMana.currMana >= 5 && Time.timeScale == 1f && delay >= 5)
        {
            isShooting = false;
            hitSomething = false;
            rch = new RaycastHit();
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hitInfo, 1000, 1 << 9))
            {
                playerMana.currMana -= 5;
                playerMana.refreshCooldown = true;
                hitInfo.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                rch = hitInfo;
                hitSomething = true;
                isShooting = true;
            }
            else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hitInfo, 1000, 1 << 8))
            {
                playerMana.currMana -= 5;
                playerMana.refreshCooldown = true;
                rch = hitInfo;
                hitSomething = true;
                isShooting = true;
            }
            else
            {
                playerMana.currMana -= 5;
                playerMana.refreshCooldown = true;
            }
            delay = 0;
        }
        else
        {
            isShooting = false;
            hitSomething = false;
            rch = new RaycastHit();
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hitInfo, 1000, 1 << 9))
            {
                rch = hitInfo;
                hitSomething = true;
                isShooting = true;
            }
            else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hitInfo, 1000, 1 << 8))
            {
                rch = hitInfo;
                hitSomething = true;
                isShooting = true;
            }
            delay++;
        }
    }
    public RaycastHit GetRaycastHit()
    {
        return rch;
    }
    public int GetDelay()
    {
        return delay;
    }
    public bool HitSomething()
    {
        return hitSomething;
    }
    public bool IsShooting()
    {
        return isShooting;
    }
}
