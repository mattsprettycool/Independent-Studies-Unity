using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka and Matt Braden
public class CameraMovement : MonoBehaviour {

    public GameObject capcam;
    float sensitivity;
    float newrotX;
    float newrotY;
    [SerializeField]
    bool isFirstPerson = true;
    GameObject thirdCamSpot, thirdCamSpotPos;
    Transform thirdCS;
    float thirdY;
    // Use this for initialization
    void Start () {
        sensitivity = 4.0f;
        newrotX=0;
        newrotY=0;
        thirdCamSpot = GameObject.FindGameObjectWithTag("3ps");
        thirdCS = thirdCamSpot.transform;
        thirdCamSpotPos = GameObject.FindGameObjectWithTag("3pspos");
        thirdY = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isFirstPerson)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                //Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (Input.mousePresent)
            {
                newrotX += Input.GetAxis("Mouse X") * sensitivity;

                newrotY = Mathf.Min(90, Mathf.Max(-90, newrotY + Input.GetAxis("Mouse Y") * sensitivity));

                capcam.transform.rotation = Quaternion.Euler(-1 * newrotY, newrotX, 0);

                gameObject.transform.rotation = Quaternion.Euler(0, newrotX - 90, 0);
            }
        }
        else
        {
            if (Input.mousePresent)
            {
                newrotX += Input.GetAxis("Mouse X") * sensitivity;

                if(thirdY<=0&& Input.GetAxis("Mouse Y") >= 0)
                    thirdY += Input.GetAxis("Mouse Y") * .05f;
                if (Input.GetAxis("Mouse Y") <= 0 && thirdY >= -.25f)
                    thirdY += Input.GetAxis("Mouse Y") * .05f;
                thirdCamSpot.transform.position = new Vector3(thirdCS.position.x, thirdY+thirdCamSpotPos.transform.position.y, thirdCS.position.z);

                newrotY = Mathf.Min(40, Mathf.Max(-60, newrotY + Input.GetAxis("Mouse Y") * sensitivity));

                capcam.transform.rotation = Quaternion.Euler(-1 * newrotY, newrotX, 0);

                gameObject.transform.rotation = Quaternion.Euler(0, newrotX - 90, 0);
            }
        }
        if(Input.GetKey(KeyCode.Escape)) Cursor.visible = true;
    }
    public bool IsInFirstPerson()
    {
        return isFirstPerson;
    }
    public void SetIsInFirstPerson(bool isInFirstPerson)
    {
        isFirstPerson = isInFirstPerson;
    }
}
