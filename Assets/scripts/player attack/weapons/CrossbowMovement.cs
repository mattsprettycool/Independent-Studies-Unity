using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class CrossbowMovement : MonoBehaviour {
    public Bolt bolt;
    Camera cammy;
    float timer;
	bool justSwitched;
    bool justStarted;
	GameObject player;

	// Use this for initialization
	void Start () {
        cammy = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		player = GameObject.FindGameObjectWithTag ("Player");
        timer = 0;
        justStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		justSwitched = Camera.main.GetComponent<ItemBar> ().justSwitched;
        LookAtCenter();
        if (Input.GetMouseButtonDown(0) && timer > 5f || Input.GetMouseButtonDown(0) && justStarted && Time.timeScale == 1f && !justSwitched)
        {
            timer = 0;
            justStarted = false;
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
		instAttk.transform.localPosition = new Vector3(0f, 0f, 0f);
		instAttk.transform.rotation = gameObject.transform.rotation;
		instAttk.transform.localRotation = Quaternion.Euler(0, 180, 0);
		instAttk.transform.localPosition = new Vector3(0f, 0f, 0);
		instAttk.transform.SetParent(null);
	}

    void LookAtCenter()
    {
        float screenPosX = Screen.width / 2;
        float screenPosY = Screen.height / 2;
        RaycastHit hit;
        Ray rayWilliamJohnson = cammy.ScreenPointToRay(new Vector3(screenPosX, screenPosY));
        if(Physics.Raycast(rayWilliamJohnson, out hit))
        {
            Vector3 vec = new Vector3(hit.transform.position.x + 90, hit.transform.position.y, hit.transform.position.z);
            transform.LookAt(vec);
        }
    }
}
