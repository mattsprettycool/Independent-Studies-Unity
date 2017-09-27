using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class EnemyAttack : MonoBehaviour {
    [SerializeField]
    public float dmgPerAttk;
    GameObject player;
	Transform kiddo;
	GameObject spear;
	SpearMovement spm;
    PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		kiddo = gameObject.transform.Find ("EnemySpear");
		spear = kiddo.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        dmgPerAttk = 5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			AttackPlayer ();
		}
	}

    //resets timer so enemy can attack again and inflicts damage, calling upon the method TakeDamage in PlayerHealth.cs
    void AttackPlayer()
    {
		if (playerHealth.currHealth > 0 && spear.GetComponent<SpearMovement>().slashing != true)
        {
			spear.GetComponent<SpearMovement> ().Start ();
            playerHealth.TakeDamage(dmgPerAttk);
        }
	}
}