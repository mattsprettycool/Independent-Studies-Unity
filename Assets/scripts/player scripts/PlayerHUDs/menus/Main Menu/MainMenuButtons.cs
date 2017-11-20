using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    public string sceneToLoad;
    [SerializeField]
    GameObject currentLoadout, newLoadout, dropdownMenu;
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Game ended!");
    }
    public void LoadScene()
    {
        newLoadout = dropdownMenu.GetComponent<DropdownLoadouts>().GetLoadout();
        currentLoadout.GetComponent<Loadout>().SetHotbar(newLoadout.GetComponent<Loadout>());
        currentLoadout.GetComponent<Loadout>().SetInventory(newLoadout.GetComponent<Loadout>());
        SceneManager.LoadScene(sceneToLoad);
    }
}
