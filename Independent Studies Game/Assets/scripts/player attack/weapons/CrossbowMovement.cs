using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class CrossbowMovement : MonoBehaviour {
    public Bolt bolt;
    float timer;
	bool justSwitched;
    bool justStarted;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        timer = 0;
        justStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * .5f, Screen.height * .5f, 0));
		justSwitched = Camera.main.GetComponent<ItemBar> ().justSwitched;
        if (Input.GetMouseButtonDown(0) && timer > 5f || Input.GetMouseButtonDown(0) && justStarted && Time.timeScale == 1f && !justSwitched)
        {
            timer = 0;
            justStarted = false;
			InstantiateBolt ();
			if (Physics.Raycast(ray, out hit, 100)){
				hit.transform.SendMessage ("TakeDamage", bolt.gameObject.GetComponent<ProjectileDamageLibrary> ().dmgPerHit, SendMessageOptions.DontRequireReceiver);
			}
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

	private void InstantiateBolt(){
		var instAttk = Instantiate(bolt);
		instAttk.transform.parent = gameObject.transform;
		instAttk.transform.localPosition = new Vector3(0f, 0f, 0f);
		instAttk.transform.rotation = gameObject.transform.rotation;
		instAttk.transform.localRotation = Quaternion.Euler(0, 180, 0);
		instAttk.transform.localPosition = new Vector3(0f, 0f, 0);
		instAttk.transform.SetParent(null);
	}
}
