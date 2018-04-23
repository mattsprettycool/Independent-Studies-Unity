using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordplus : MonoBehaviour {
    Animator anim;
    int maxAngle = 60;
    float range = 10;
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
        Ray rangeRay = new Ray(new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z), new Vector3(Camera.main.transform.forward.x,0, Camera.main.transform.forward.z));
        Debug.Log(rangeRay.GetPoint(range));
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            //make ray to enemy UVU
        }
        //foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        //{
        //RaycastHit hit;
        //if (Physics.Raycast(Camera.main.transform.position, obj.transform.position, out hit))
        //{
        //Vector2 point1 = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.z);
        //Vector2 point2 = new Vector2(obj.transform.position.x, obj.transform.position.z);
        //Vector2 point3 = new Vector2()
        //if (GetDistance(transform.position, obj.transform.position) <= 10 && (hit.normal.x/ Mathf.Abs(hit.normal.x)) == (Camera.main.transform.rotation.x / Mathf.Abs(Camera.main.transform.rotation.x))) {
        //obj.GetComponent<EnemyHealth>().TakeDamage(25);
        //}
        //}
        //}
    }
    float GetDistance(Vector3 x, Vector3 y)
    {
        return Mathf.Sqrt(Mathf.Pow(y.x - x.x, 2) + Mathf.Pow(y.z - x.z, 2));
    }
}
