using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka and Matt Braden
public class CameraMovement : MonoBehaviour {

    public GameObject capcam;
    bool ShowCursor;
    [SerializeField]
    float sensitivity;

    float newrotX;
    float newrotY;

    // Use this for initialization
    void Start () {
        sensitivity = 5.0f;
        ShowCursor = false;
        newrotX=0;
        newrotY=0;
		if (ShowCursor == false)
        {
            Cursor.visible = false;
        }
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
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
