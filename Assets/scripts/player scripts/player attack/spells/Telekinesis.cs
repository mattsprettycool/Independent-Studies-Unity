using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Telekinesis : MonoBehaviour {
    Transform currentlySelectedEnemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentlySelectedEnemy = GetNearestEnemy(100).transform;
            currentlySelectedEnemy.GetComponent<NavMeshAgent>().velocity = Vector3.Normalize(transform.position)*100;
        }
    }

    GameObject GetNearestEnemy(float maxDistance)
    {
        GameObject nearestObj = null;
        float closestEnemy = float.MaxValue;
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            Debug.Log(GetDistance(transform.position.x, transform.position.z, obj.transform.position.x, obj.transform.position.z));
            if ((GetDistance(transform.position.x, transform.position.z, obj.transform.position.x, obj.transform.position.z) < closestEnemy) && (GetDistance(transform.position.x, transform.position.z, obj.transform.position.x, obj.transform.position.z) <= maxDistance))
                nearestObj = obj;
        }
        
        return nearestObj;
    }

    float GetDistance(float myX, float myZ, float theirX, float theirZ)
    {
        return Mathf.Sqrt(Mathf.Pow((myX+theirX),2)+ Mathf.Pow((myZ + theirZ), 2));
    }
}
