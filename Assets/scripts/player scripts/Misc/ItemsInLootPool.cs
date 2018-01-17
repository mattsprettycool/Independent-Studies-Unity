using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInLootPool : MonoBehaviour {
    [SerializeField]
    GameObject[] dropableItems;
    public GameObject[] GetDroppableArray()
    {
        return dropableItems;
    }
}
