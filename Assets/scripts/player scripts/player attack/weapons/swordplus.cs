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
        Ray rangeRay = new Ray(RemoveY(Camera.main.transform.position), RemoveY(Camera.main.transform.forward));
        //Debug.DrawRay(RemoveY(Camera.main.transform.position), RemoveY(Camera.main.transform.forward), Color.blue, 10000000);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            Ray enemyRay = new Ray(RemoveY(Camera.main.transform.position), RemoveY(GetRelativeVector(Camera.main.transform.position, obj.transform.position)));
            //Debug.DrawRay(RemoveY(Camera.main.transform.position), RemoveY(GetRelativeVector(Camera.main.transform.position, obj.transform.position)), Color.red, 10000000);
            //Next thing I need to do is get the ray to register if it is close - or maybe start with the angle stuff because it is easier
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
    Vector3 RemoveY(Vector3 myVector)
    {
        return new Vector3(myVector.x, 0, myVector.z);
    }
    Vector3 GetRelativeVector(Vector3 newOrigin, Vector3 otherPoint)
    {
        return new Vector3(otherPoint.x - newOrigin.x, otherPoint.y - newOrigin.y, otherPoint.z - newOrigin.z);
    }
}
