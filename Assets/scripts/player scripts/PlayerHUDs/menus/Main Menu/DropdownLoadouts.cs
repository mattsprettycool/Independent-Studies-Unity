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
	
	// Update is called once per frame
	void Update () {
        Dropdown myDropdown = gameObject.GetComponent<Dropdown>();
        SetLoadout(myDropdown.value);
	}
    void SetLoadout(int index)
    {
        //use the current loadout prefab
    }
}
