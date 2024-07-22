using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalMultiPlayerPauseMenuController : PauseMenuController
{
    public PlayerInstantiater playerInstantiater;
    public CharacterSelectionManager characterSelectionManager;


    void Awake()
    {
        pauseMenu.SetActive(false);

        playerInstantiater = FindObjectOfType<PlayerInstantiater>();
        characterSelectionManager = playerInstantiater.characterSelectionManager;
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

    public void ReturnToCharacterSelect()
    {
        if (!inputEnabled) { return; }

        Time.timeScale = 1f;
        characterSelectionManager.DestroySelf();
        const string sceneName = "CharacterSelect";
        SceneManager.LoadScene(sceneName);
    }

    override public void BackToMainMenu()
    {
        if (!inputEnabled) { return; }

        Time.timeScale = 1f;
        characterSelectionManager.DestroySelf();
        const string sceneName = "MainMenu";
        SceneManager.LoadScene(sceneName);
    }
}
