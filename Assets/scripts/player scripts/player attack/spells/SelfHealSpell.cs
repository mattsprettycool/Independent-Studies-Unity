using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHealSpell : MonoBehaviour {
    SpellManager spellManager;
    PlayerHealth playerHealth;
    float curTime = 0;
    [SerializeField]
    float timeToWait = 100;
    // Use this for initialization
    void Start () {
        spellManager = gameObject.GetComponent<SpellManager>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && spellManager.HasManaNumber(10))
        {
            curTime = timeToWait;
            spellManager.LoseMana(10);
            spellManager.SetManaCooldown();
        }
        if (Input.GetKey(KeyCode.Mouse0) && spellManager.HasManaNumber())
        {
            if (curTime > 0)
            {
                curTime--;
            }
            else
            {
                spellManager.LoseMana();
                spellManager.SetManaCooldown();
                if(playerHealth.currHealth < playerHealth.startHealth)
                {
                    playerHealth.currHealth += 1;
                }
                curTime = timeToWait;
            }
        }
    }
}
