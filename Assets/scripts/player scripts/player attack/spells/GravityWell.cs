using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//by Matt Braden
public class GravityWell : MonoBehaviour
{
    [SerializeField]
    public GameObject gravAOE;
    [SerializeField]
    public GameObject fakeGravAOE;
    SpellManager spellManager;
    // Use this for initialization
    void Start()
    {
        spellManager = gameObject.GetComponent<SpellManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && spellManager.HasManaNumber() && Time.timeScale == 1f)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward*1000, out hitInfo, 1000, 1 << 8))
            {
                spellManager.LoseMana();
                spellManager.SetManaCooldown();
                var attackInst = Instantiate(gravAOE);
                attackInst.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 1.266f, hitInfo.point.z);
                attackInst.transform.rotation = hitInfo.transform.rotation;
            }
        }
        else
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward*1000, out hitInfo, 1000, 1<<8)&& spellManager.HasManaNumber())
            {
                if (hitInfo.collider.tag == "Floor")
                {
                    Destroy(GameObject.FindGameObjectWithTag("attackPreview"));
                    var attackInst = Instantiate(fakeGravAOE);
                    attackInst.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 1.266f, hitInfo.point.z);
                    attackInst.transform.rotation = hitInfo.transform.rotation;
                }
                else
                {
                    try
                    {
                        Destroy(GameObject.FindGameObjectWithTag("attackPreview"));
                    }
                    catch(Exception e)
                    {
                        Debug.Log(e);
                    }
                }
            }else
                try
                {
                    Destroy(GameObject.FindGameObjectWithTag("attackPreview"));
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            if(Input.GetKey(KeyCode.Alpha0)|| Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Alpha6) || Input.GetKey(KeyCode.Alpha7) || Input.GetKey(KeyCode.Alpha8) || Input.GetKey(KeyCode.Alpha9) || Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("attackPreview"));
            }
        }
    }
}