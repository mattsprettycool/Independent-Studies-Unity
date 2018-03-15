using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordplus : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            AttackAllInRange();
            anim.Play("SwordAnim1");
        }
	}
    void AttackAllInRange()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, obj.transform.position, out hit))
            {
                if (GetDistance(transform.position, obj.transform.position) <= 5 && (hit.normal.x/ Mathf.Abs(hit.normal.x)) == (Camera.main.transform.rotation.x / Mathf.Abs(Camera.main.transform.rotation.x))) {
                    obj.GetComponent<EnemyHealth>().TakeDamage(10);
                }
            }
        }
    }
    float GetDistance(Vector3 x, Vector3 y)
    {
        return Mathf.Sqrt(Mathf.Pow(y.x - x.x, 2) + Mathf.Pow(y.z - x.z, 2));
    }
}
