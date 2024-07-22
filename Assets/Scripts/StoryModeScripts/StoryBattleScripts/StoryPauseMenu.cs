using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryPauseMenu : PauseMenuController
{
    void Awake()
    {
        pauseMenu.SetActive(false);
    }

    override public void OnSetup()
    {
        if (!isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }


    private IEnumerator InputDelay()
    {
        yield return new WaitForSeconds(1);
        inputEnabled = true;
    }

    override public void PauseGame()
    {
        pauseMenu.SetActive(true);
        //Setting timescale to freezes all FixedUpdate functions.
        Time.timeScale = 0f;
        isPaused = true;
        StartCoroutine(InputDelay());
    }

    override public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartStoryMode()
    {
        if (!inputEnabled) { return; }

        Time.timeScale = 1f;
        const string sceneName = "StoryCutscene";
        SceneManager.LoadScene(sceneName);
    }

    override public void BackToMainMenu()
    {
        if (!inputEnabled) { return; }

        Time.timeScale = 1f;
        const string sceneName = "MainMenu";
        SceneManager.LoadScene(sceneName);
    }
}
