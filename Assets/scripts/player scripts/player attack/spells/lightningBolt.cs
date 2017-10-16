using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningBolt : MonoBehaviour {
    PlayerMana playerMana;
    [SerializeField]
    float damage = 10f;
    int delay = 5;
    // Use this for initialization
    void Start () {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Mouse0) && playerMana.currMana >= 5 && Time.timeScale == 1f && delay >= 5)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hitInfo, 1000, 1 << 9))
            {
                playerMana.currMana -= 5;
                playerMana.refreshCooldown = true;
                hitInfo.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hitInfo, 1000, 1 << 8))
            {
                playerMana.currMana -= 5;
                playerMana.refreshCooldown = true;
            }
            else
            {
                playerMana.currMana -= 5;
                playerMana.refreshCooldown = true;
            }
            delay = 0;
        }
        else
            delay++;
    }
}
