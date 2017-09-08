using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class CameraMovement : MonoBehaviour {

    public GameObject capcam;
    bool ShowCursor;
    [SerializeField]
    float sensitivity;

    // Use this for initialization
    void Start () {
        sensitivity = 5.0f;
        ShowCursor = false;
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
            float newrotX = Input.GetAxis("Mouse X") * sensitivity;
            float newrotY = Input.GetAxis("Mouse Y") * sensitivity;
            transform.Rotate(0, newrotX, 0);
            capcam.transform.Rotate(-1*newrotY, 0, 0);
            gameObject.transform.Rotate(0, newrotX, 0);
        }
    }
}
