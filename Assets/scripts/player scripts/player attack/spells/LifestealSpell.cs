using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifestealSpell : MonoBehaviour {
    LineRenderer lr;
    GameObject player;
    SpellManager spm;
    [SerializeField]
    bool isPercentBased = false;
    [SerializeField]
    float damagePercentage = .0025f;
    [SerializeField]
    float staticDamage = .025f;
    PlayerHealth playerHealth;
    // Use this for initialization
    void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        spm = gameObject.GetComponent<SpellManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        lr = gameObject.GetComponentInChildren<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lr.transform.rotation = Quaternion.LookRotation(Vector3.zero, Vector3.zero);
        lr.transform.position = player.transform.position;
        if (Input.GetMouseButton(0) && spm.HasManaNumber())
        {
            spm.LoseMana();
            spm.SetManaCooldown();
            GameObject enemy = FindEnemyInRange(10);
            lr.SetPosition(1, new Vector3(enemy.transform.position.x - player.transform.position.x, enemy.transform.position.y - player.transform.position.y, enemy.transform.position.z - player.transform.position.z));
            if (isPercentBased)
            {
                float enemyHealth = enemy.GetComponent<EnemyHealth>().startHealth;
                float currDamage = enemyHealth * damagePercentage;
                enemy.GetComponent<EnemyHealth>().TakeDamage(currDamage);
                if (playerHealth.currHealth < 100)
                    playerHealth.currHealth += currDamage/4;
            }
            else
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(staticDamage);
                if (playerHealth.currHealth < 100)
                    playerHealth.currHealth += staticDamage/4;
            }
        }else
            lr.SetPosition(1, new Vector3(0, 0, 0));
    }
    GameObject FindEnemyInRange(int range)
    {
        return GameObject.FindGameObjectWithTag("Enemies");
    }
}
