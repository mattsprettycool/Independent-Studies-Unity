using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordplus : MonoBehaviour {
    Animator anim;
    PlayerStamina playerStamina;
    int maxAngle = 10;
    float range = 3;
    int damage = 25;
    [SerializeField]
    GameObject swordProj;
    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        playerStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStamina>();
    }
    void Update () {
        if (Input.GetMouseButton(0))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("swingsword")&&playerStamina.currStamina>0)
            {
                playerStamina.currStamina -= 5;
                AttackAllInRange();
                anim.Play("SwordSwing2");
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currHealth >= 100)
                {
                    Instantiate(swordProj, gameObject.transform.position, Camera.main.transform.rotation);
                }
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
            if(GetDistance(enemyRay.GetPoint(0), obj.transform.position) <= range)
            {
                Debug.Log(GetAngleFromRays(rangeRay, enemyRay));
                if(GetAngleFromRays(rangeRay, enemyRay)<=maxAngle)
                    obj.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
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
    float GetAngleFromRays(Ray relativeOrigin, Ray angleRay)
    {
        return Vector3.Angle(angleRay.GetPoint(range), relativeOrigin.GetPoint(range));
    }
}
