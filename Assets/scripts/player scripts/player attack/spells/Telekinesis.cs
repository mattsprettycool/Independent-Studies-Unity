using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour {
    GameObject currentlySelectedEnemy;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //debug
            Destroy(GetNearestEnemy(25));
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
