using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka and Matt Braden
public class CameraMovement : MonoBehaviour {

    public GameObject capcam;
    [SerializeField]
    float sensitivity;

    float newrotX;
    float newrotY;

    // Use this for initialization
    void Start () {
        sensitivity = 5.0f;
        newrotX=0;
        newrotY=0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.C))
        {
                //Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.mousePresent)
        {
            newrotX += Input.GetAxis("Mouse X") * sensitivity;

            newrotY = Mathf.Min(90, Mathf.Max(-90, newrotY + Input.GetAxis("Mouse Y") * sensitivity));

            capcam.transform.rotation = Quaternion.Euler(-1*newrotY, newrotX , 0);

            gameObject.transform.rotation = Quaternion.Euler(0, newrotX-90, 0);
        }
        if(Input.GetKey(KeyCode.Escape)) Cursor.visible = true;
    }
}
