using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHealSpell : MonoBehaviour {
    PlayerMana playerMana;
    PlayerHealth playerHealth;
    float curTime = 0;
    [SerializeField]
    float timeToWait = 100;
    // Use this for initialization
    void Start () {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerMana.currMana >= 10)
        {
            curTime = timeToWait;
            playerMana.currMana -= 10;
            playerMana.refreshCooldown = true;
        }
        if (Input.GetKey(KeyCode.Mouse0) && playerMana.currMana > 0)
        {
            if (curTime > 0)
            {
                curTime--;
            }
            else
            {
                playerMana.currMana -= 5;
                playerMana.refreshCooldown = true;
                if(playerHealth.currHealth < playerHealth.startHealth)
                {
                    playerHealth.currHealth += 1;
                }
                curTime = timeToWait;
            }
        }
    }
}
