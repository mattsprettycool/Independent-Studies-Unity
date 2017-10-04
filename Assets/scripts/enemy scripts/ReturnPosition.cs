using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPosition : MonoBehaviour {

	public Vector3 ReturnPos()
    {
        return gameObject.transform.position;
    }
}
