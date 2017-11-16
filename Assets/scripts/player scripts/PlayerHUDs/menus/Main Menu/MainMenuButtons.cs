using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    public string sceneToLoad;
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Game ended!");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
