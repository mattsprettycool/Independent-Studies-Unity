using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealGameTest : MonoBehaviour {
    [SerializeField]
    public bool gameTest = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameTest && Time.timeScale == 1f)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (Input.GetKey(KeyCode.Escape))
                Application.Quit();
        }
        else if (Time.timeScale == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
	}
}
