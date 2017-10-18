using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour {
    public SlingMovement sling;
    float timer;
    float timeBeforeDeletion;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        timer = 0;
        timeBeforeDeletion = 10;
        rb = gameObject.GetComponent<Rigidbody>();
		rb.AddRelativeForce(new Vector3(150 * (1 + (.01f * sling.timeHeld)), 0, 0));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timer >= timeBeforeDeletion)
		{
			GameObject.Destroy(this.gameObject);
		}
		timer += Time.deltaTime;
		gameObject.GetComponent<ProjectileDamageLibrary>().travelTime += Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player" && other.tag != "attacks")
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
