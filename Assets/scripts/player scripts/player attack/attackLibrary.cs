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
    public float[] savedValues = new float[10];
    [SerializeField]
    public bool hasCooldownAtSpot = false;
    [SerializeField]
    public int cooldownSpot = 0;
    public float[] GetSavedValues()
    {
        return savedValues;
    }
    public void SetSavedValues(float[] newValues)
    {
        savedValues = newValues;
    }
    public void SetSavedValuesAtSpot(int spot ,float newValue)
    {
        savedValues[spot] = newValue;
    }
}
