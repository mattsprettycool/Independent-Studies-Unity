using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Telekinesis : MonoBehaviour {
    Transform currentlySelectedEnemy;
    bool enemySelected = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!enemySelected)
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hitInfo, 20, 1 << 9))
                {
                    if (hitInfo.collider.tag.Equals("Enemies"))
                    {
                        currentlySelectedEnemy = hitInfo.collider.GetComponent<Transform>();
                        enemySelected = true;
                    }
                }
            }
            else
            {
                currentlySelectedEnemy.GetComponent<NavMeshAgent>().velocity = new Vector3(100, 0, 0);
                enemySelected = false;
            }
        }
        if (enemySelected)
        {
            GameObject telePointer = GameObject.FindGameObjectWithTag("tloc");
            currentlySelectedEnemy.position = new Vector3(telePointer.transform.position.x, telePointer.transform.position.y, telePointer.transform.position.z);
        }
    }

    //GameObject GetNearestEnemy(float maxDistance)
    //{
     //   GameObject nearestObj = null;
     //   float closestEnemy = float.MaxValue;
     //   foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
     //   {
     //       Debug.Log(GetDistance(transform.position.x, transform.position.z, obj.transform.position.x, obj.transform.position.z));
     //       if ((GetDistance(transform.position.x, transform.position.z, obj.transform.position.x, obj.transform.position.z) < closestEnemy) && (GetDistance(transform.position.x, transform.position.z, obj.transform.position.x, obj.transform.position.z) <= maxDistance))
     //           nearestObj = obj;
     //   }
        
      //  return nearestObj;
    //}

    //float GetDistance(float myX, float myZ, float theirX, float theirZ)
    //{
    //    return Mathf.Sqrt(Mathf.Pow((myX+theirX),2)+ Mathf.Pow((myZ + theirZ), 2));
    //}
}
