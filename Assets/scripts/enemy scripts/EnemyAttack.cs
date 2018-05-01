using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public float dmgPerAttk;
	public float timeBetweenAttk;
	float timer;
	bool inRange;
	GameObject player;
	PlayerHealth playerHealth;
    ArtificialTimeManager realTime;
    float range = 3;
    bool startAttack = false;
    bool isAttacking = false;
    float defChargeTime = 2;
    float chargeTime = 0;
    bool inMyRange = false;
	// Use this for initialization
	void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        timer = 0;
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		dmgPerAttk = 2;
		timeBetweenAttk = .1f;
		inRange = false;
	}
    void FixedUpdate()
    {
        if (realTime.IsTimeOn())
        {
            //timer += Time.deltaTime;
            //if (inRange && timer > timeBetweenAttk && !playerHealth.GetBlocking())
            //{
                //timer = 0;
                //playerHealth.TakeDamage(dmgPerAttk);
            //}
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, GetRelativeVector(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position), out hit, range))
            {
                if (hit.collider.tag.Equals("Player") && !startAttack && !isAttacking)
                {
                    startAttack = true;
                    inMyRange = true;
                }
            }
            else
                inMyRange = false;
            if (startAttack)
            {
                gameObject.GetComponent<EnemyMovement>().SetStopped(true);
                chargeTime = defChargeTime;
                isAttacking = true;
                startAttack = false;
            }
            if (isAttacking && chargeTime > 0)
            {
                chargeTime -= .1f;
            }else if (isAttacking)
            {
                if(inMyRange)
                    playerHealth.TakeDamage(dmgPerAttk);
                isAttacking = false;
                gameObject.GetComponent<EnemyMovement>().SetStopped(false);
            }
        }
    }
    void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"&&realTime.IsTimeOn()) {
            inRange = true;
		}
	}
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"&&realTime.IsTimeOn())
        {
            inRange = false;
        }
    }
    Vector3 GetRelativeVector(Vector3 newOrigin, Vector3 otherPoint)
    {
        return new Vector3(otherPoint.x - newOrigin.x, otherPoint.y - newOrigin.y, otherPoint.z - newOrigin.z);
    }
}