using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;

    public bool isPaused;
    protected bool inputEnabled;


    public abstract void OnSetup();

    public abstract void PauseGame();

    public abstract void ResumeGame();


    public abstract void BackToMainMenu();
}
