using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialTimeManager : MonoBehaviour {
    [SerializeField]
    bool timeIsGoingForward = true;
    public void SetTime(bool timeIsOn)
    {
        timeIsGoingForward = timeIsOn;
    }
    public bool IsTimeOn()
    {
        return timeIsGoingForward;
    }
}
