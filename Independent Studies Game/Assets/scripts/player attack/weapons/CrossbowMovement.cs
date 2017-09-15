using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class CrossbowMovement : MonoBehaviour {
    public Bolt bolt;
    float timer;
    bool justStarted;
	// Use this for initialization
	void Start () {
        timer = 0;
        justStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && timer > 5f || Input.GetMouseButtonDown(0) && justStarted)
        {
            timer = 0;
            justStarted = false;
            var instAttk = Instantiate(bolt);
            instAttk.transform.parent = gameObject.transform;
            instAttk.transform.localPosition = new Vector3(0f, 0f, 0f);
            instAttk.transform.rotation = gameObject.transform.rotation;
            instAttk.transform.localRotation = Quaternion.Euler(0, 180, 0);
            instAttk.transform.localPosition = new Vector3(0f, 0f, 0);
            instAttk.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
