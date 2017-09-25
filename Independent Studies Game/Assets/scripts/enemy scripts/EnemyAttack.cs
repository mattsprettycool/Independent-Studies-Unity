using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyAttack : MonoBehaviour {
    [SerializeField]
    public float dmgPerAttk;
    GameObject player;
    PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        dmgPerAttk = .25f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
    void OnCollisionStay(Collision col)
    {
       if (col.gameObject == player)
        {
            AttackPlayer();
        } 
    }

    //resets timer so enemy can attack again and inflicts damage, calling upon the method TakeDamage in PlayerHealth.cs
    void AttackPlayer()
    {
        if (playerHealth.currHealth > 0)
        {
            playerHealth.TakeDamage(dmgPerAttk);
        }
	}
}