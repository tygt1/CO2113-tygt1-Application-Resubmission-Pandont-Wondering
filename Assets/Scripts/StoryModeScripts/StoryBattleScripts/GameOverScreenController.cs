using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void RetryBattle()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void RestartStoryMode()
    {
        const string sceneName = "StoryCutscene";
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMainMenu()
    {
        const string sceneName = "MainMenu";
        SceneManager.LoadScene(sceneName);
    }
}
