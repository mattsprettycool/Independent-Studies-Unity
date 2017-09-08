using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class CameraMovement : MonoBehaviour {
    public GameObject player;
    public GameObject capcam;
    bool ShowCursor;
    [SerializeField]
    float sensitivity;
    float newrotX;
    float newrotY;
    float camrot;

    // Use this for initialization
    void Start () {
        sensitivity = 5.0f;
        ShowCursor = false;
	    if (ShowCursor == false)
        {
            Cursor.visible = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        newrotX = Input.GetAxis("Mouse X") * sensitivity;
        newrotY = Input.GetAxis("Mouse Y") * sensitivity;
        CheckVerticalRotation();
        capcam.transform.Rotate(-1 * newrotY, 0, 0);
        gameObject.transform.Rotate(0, newrotX, 0);
    }

    public void CheckVerticalRotation()
    {
        if(Mathf.Abs(capcam.transform.localEulerAngles.x) < -60)
        {
            capcam.transform.Rotate(30, 0, 0);
        }
    }
}
