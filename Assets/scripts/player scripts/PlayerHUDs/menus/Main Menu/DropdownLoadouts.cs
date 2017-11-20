using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownLoadouts : MonoBehaviour {
    [SerializeField]
    public GameObject[] loadouts = new GameObject[2];
	// Use this for initialization
	void Start () {
        List<string> loadoutNames = new List<string>();
		foreach(GameObject obj in loadouts)
        {
            loadoutNames.Add(obj.GetComponent<Loadout>().GetName());
        }
        gameObject.GetComponent<Dropdown>().AddOptions(loadoutNames);

    }
    public GameObject GetLoadout()
    {
        foreach(GameObject obj in loadouts)
        {
            Debug.Log(gameObject.GetComponent<Dropdown>().value);
            if (obj.GetComponent<Loadout>().GetName().Equals(loadouts[gameObject.GetComponent<Dropdown>().value].GetComponent<Loadout>().GetName()))
                return obj;
        }
        return null;
    }
}
