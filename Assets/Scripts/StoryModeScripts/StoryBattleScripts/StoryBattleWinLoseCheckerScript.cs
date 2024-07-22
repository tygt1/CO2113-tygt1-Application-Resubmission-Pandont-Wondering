using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryBattleWinLoseChecker : MonoBehaviour
{

    [SerializeField]
    public List<Character> characterList = new List<Character>();
    Character playerInstance;
    Character enemyInstance;



    public Boolean playerDead = false;
    public Boolean enemyDead = false;

    [SerializeField]
    private GameObject gameOverScreenController;

    private string sceneName;

    private void Awake()
    { 
        playerInstance = characterList[0];
        enemyInstance = characterList[1];
    }

    void Update()
    {
        if (playerInstance.characterDead)
        {
            playerDead = true;
        }
        if (enemyInstance.characterDead)
        {
            enemyDead = true;
        }


        if (playerDead || enemyDead)
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        if (playerDead == false && enemyDead == true)
        {
            string activeSceneName = SceneManager.GetActiveScene().name;

            switch (activeSceneName)
            {
                case "StoryModeBattleOne":
                    sceneName = "StoryCutsceneTwo";
                    break;

                case "StoryModeBattleTwo":
                    sceneName = "BeatStoryMode";
                    break;

                default:
                    break;
            }

            SceneManager.LoadScene(sceneName);
        }
        else if ((playerDead == true && enemyDead == false) || (playerDead == true && enemyDead == true))
        {
            gameOverScreenController.SetActive(true);
        }
    }
}
