using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordplus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            AttackAllInRange();
        }
	}
    void AttackAllInRange()
    {//hey so when I get back why don't you make it so if the ray from the player to the enemy is positve x then yee
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            if (GetDistance(transform.position, obj.transform.position) <= 4)
                obj.GetComponent<EnemyHealth>().TakeDamage(10);
        }
    }
    float GetDistance(Vector3 x, Vector3 y)
    {
        return Mathf.Sqrt(Mathf.Pow(y.x - x.x, 2) + Mathf.Pow(y.z - x.z, 2));
    }
}
