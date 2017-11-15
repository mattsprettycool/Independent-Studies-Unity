using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("yee");
    }
}
