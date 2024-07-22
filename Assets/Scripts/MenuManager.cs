using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        const string sceneName = "CharacterSelect";
        SceneManager.LoadScene(sceneName);
    }

    public void StartStoryMode()
    {
        const string sceneName = "StoryCutsceneOne";
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToMainMenu()
    {
        const string sceneName = "MainMenu";
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
