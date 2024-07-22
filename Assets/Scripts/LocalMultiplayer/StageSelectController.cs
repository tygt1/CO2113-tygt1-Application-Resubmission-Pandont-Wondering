using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour
{
    public void ChooseBambooForest()
    {
        const string sceneName = "LocalMultiplayerBambooForest";
        SceneManager.LoadScene(sceneName);
    }

    public void ChoosePandontHouse()
    {
        const string sceneName = "LocalMultiplayerPandontHouse";
        SceneManager.LoadScene(sceneName);
    }

    public void ChooseRandom()
    {
        float randomStage = UnityEngine.Random.Range(0, 1);
        
        switch (randomStage)
        {
            case 0:
                ChooseBambooForest(); 
                break;
            case 1:
                ChoosePandontHouse(); 
                break;
            default:
                break;
        }
    }
}
