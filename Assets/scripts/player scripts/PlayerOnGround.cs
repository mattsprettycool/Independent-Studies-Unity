using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : MonoBehaviour {
    [SerializeField]
    bool isOnGround = false;
    public bool IsOnGround()
    {
        return isOnGround;
    }
    private void OnTriggerStay(Collider collision)
    {
        string tag = collision.tag;
        Debug.Log(tag);
        if(tag.Equals("Floor")|| tag.Equals("enemy"))
        isOnGround = true;
    }
    private void OnTriggerExit(Collider collision)
    {
        isOnGround = false;
    }
}
