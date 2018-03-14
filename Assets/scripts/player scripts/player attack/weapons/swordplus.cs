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
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, obj.transform.position, out hit))
            {
                if (GetDistance(transform.position, obj.transform.position) <= 4 && (hit.transform.position.x / Mathf.Abs(hit.transform.position.x)) == (Camera.main.transform.position.x / Mathf.Abs(Camera.main.transform.position.x))) {
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
