using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarBackground : MonoBehaviour {
	void Start () {
        transform.localScale = new Vector3(gameObject.GetComponentInChildren<Transform>().localScale.x + .1f, transform.localScale.y, transform.localScale.z);
	}
}
