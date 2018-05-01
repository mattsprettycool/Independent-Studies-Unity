using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//by Jai Saka
public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    public float startHealth;
    public float currHealth;
    float timer;
    public EnemySpawn enemySpawn;
    PlayerSpawn pSpawn;
	public bool bleeding;
	public float bleedDmg;
	public GameObject threeDText;
    bool isGoingToDie = false;
    ArtificialTimeManager realTime;
    float timeDamage = 0;
    // Use this for initialization
    void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        enemySpawn = GameObject.FindGameObjectWithTag("enemymanager").GetComponent<EnemySpawn>();
        pSpawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpawn>();
		if (gameObject.name == "EnemyGiant" || gameObject.name == "EnemyGiant(Clone)") {
			startHealth = 200;
		}
		if (gameObject.name == "Enemy" || gameObject.name == "Enemy(Clone)") {
			startHealth = 100;
		}
		if (gameObject.name == "RealEnemyMage" || gameObject.name == "RealEnemyMage(Clone)") {
			startHealth = 50;
		}
		if (gameObject.name == "EnemyHealer" || gameObject.name == "EnemyHealer(Clone)") {
			startHealth = 50;
		}
		if (gameObject.name == "EnemyThrall" || gameObject.name == "EnemyThrall(Clone)") {
			startHealth = 25;
			enemySpawn.enemiesInArena++;
		}
        currHealth = startHealth;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (realTime.IsTimeOn())
        {
            currHealth -= timeDamage;
            timeDamage = 0;
        }
        if (currHealth <= 0)
        {
            isGoingToDie = true;
        }
		if (bleeding) {
			currHealth -= bleedDmg;
		}
        if (pSpawn.GetArenaState() == false)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
    private void LateUpdate()
    {
        if (IsDead())
        {
			enemySpawn.enemiesKilled++;
			enemySpawn.enemiesInArena--;
			Debug.Log ("Enemies in Arena: " + enemySpawn.enemiesInArena);
			GameObject.Destroy(this.gameObject);
        }
    }
	public void TakeDamage(float dmg){
        if (realTime.IsTimeOn())
        {
            if (currHealth - dmg <= 0)
                isGoingToDie = true;
            currHealth -= dmg;
			threeDText.GetComponent<TextMesh> ().text = ""+dmg;
			if (dmg > 0 && dmg <= 10) {
				threeDText.GetComponent<TextMesh> ().color = Color.blue;
			}
			if (dmg > 10  && dmg <= 25) {
				threeDText.GetComponent<TextMesh> ().color = Color.magenta;
			}
			GameObject.Instantiate (threeDText, gameObject.transform.position, new Quaternion(0,0,0,0));
        }
        else
        {
            timeDamage += dmg;
        }
	}
    public float GetHealth()
    {
        return currHealth;
    }
    public float GetBaseHealth()
    {
        return startHealth;
    }
    public bool IsDead()
    {
        if (isGoingToDie) return true;
        return currHealth <= 0;
    }
}
