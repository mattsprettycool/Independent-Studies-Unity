using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class BoltSpawner : MonoBehaviour {
	//FIX THIS SHIT LATER
	public Bolt bolt;
	float timer;
	bool justSwitched;
	bool justStarted;

	// Use this for initialization
	void Start () {
		timer = 0;
		justStarted = true;
	}

	// Update is called once per frame
	void Update () {
		justSwitched = GameObject.FindGameObjectWithTag("ItemBarHolder").GetComponent<ItemBar> ().justSwitched;
        if (Input.GetMouseButtonDown(0) && timer > 1f || Input.GetMouseButtonDown(0) && justStarted && Time.timeScale == 1f && !justSwitched)
		{
            justStarted = false;
            timer = 0;
			LookAtCenter();
			InstantiateBolt ();
		}
	}
	void FixedUpdate()
	{
		timer += Time.deltaTime;
	}

	private void InstantiateBolt(){
		var instAttk = Instantiate(bolt);
		instAttk.transform.parent = gameObject.transform;
		instAttk.transform.localPosition = new Vector3(0, 0, 0);
		instAttk.transform.rotation = gameObject.transform.rotation;
		instAttk.transform.localRotation = Quaternion.Euler(0, transform.rotation.y-90, 0);
		instAttk.transform.localPosition = new Vector3(0, 0, 0);
		instAttk.transform.SetParent(null);
	}

	void LookAtCenter()
	{
		RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hit, 1000, 1 << 9))
		{
			transform.LookAt(hit.point);
		}
		else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1000, out hit, 1000, 1 << 8))
		{
			transform.LookAt(hit.point);
		}
	}
}