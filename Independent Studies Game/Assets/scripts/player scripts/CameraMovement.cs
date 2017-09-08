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
<<<<<<< HEAD
            capcam.transform.Rotate(30, 0, 0);
=======
            newrotX += Input.GetAxis("Mouse X") * sensitivity;
            newrotY = Mathf.Min(90, Mathf.Max(-90, newrotY + Input.GetAxis("Mouse Y") * sensitivity));
            capcam.transform.rotation = Quaternion.Euler(-1*newrotY, newrotX , 0);
            gameObject.transform.rotation = Quaternion.Euler(0, capcam.transform.rotation.y, 0);
>>>>>>> aa3f1f29a188410c8e9b7a5437bb722ccf6a093d
        }
        if(Input.GetKey(KeyCode.Escape)) Cursor.visible = true;
    }
}
