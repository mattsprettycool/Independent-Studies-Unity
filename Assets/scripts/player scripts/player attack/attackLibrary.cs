using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class attackLibrary : MonoBehaviour {
    [SerializeField]
    public Vector3 pos;
    [SerializeField]
    public float rotX, rotY, rotZ;
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    public bool IsInThirdPerson;
    [SerializeField]
    public string UUID;
}
