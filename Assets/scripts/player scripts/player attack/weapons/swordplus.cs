using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordplus : MonoBehaviour {
    Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    void Update () {
        if (Input.GetMouseButton(0))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("swingsword"))
            {
                AttackAllInRange();
                anim.Play("SwordSwing1");
            }
        }
	}
    void AttackAllInRange()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, obj.transform.position, out hit))
            {
                if (GetDistance(transform.position, obj.transform.position) <= 8 && (hit.normal.x/ Mathf.Abs(hit.normal.x)) == (Camera.main.transform.rotation.x / Mathf.Abs(Camera.main.transform.rotation.x))) {
                    obj.GetComponent<EnemyHealth>().TakeDamage(25);
                }
            }
        }
    }
    float GetDistance(Vector3 x, Vector3 y)
    {
        return Mathf.Sqrt(Mathf.Pow(y.x - x.x, 2) + Mathf.Pow(y.z - x.z, 2));
    }
}
