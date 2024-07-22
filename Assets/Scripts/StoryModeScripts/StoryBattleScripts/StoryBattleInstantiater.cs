using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StoryBattleInstantiater : MonoBehaviour
{
    [SerializeField]
    public List<Character> characterList = new List<Character>();

    [SerializeField]
    public List<Image> healthBarImage = new List<Image>();

    private void Awake()
    {
        Character player = characterList[0];
        Character enemy = characterList[1];

        player.GetComponent<HealthBar>().enabled = true;
        enemy.GetComponent<HealthBar>().enabled = true;
        HealthBar playerHealthBar = player.GetComponent<HealthBar>();
        HealthBar enemyHealthBar = enemy.GetComponent<HealthBar>();
        playerHealthBar.healthBarImage = healthBarImage[0];
        enemyHealthBar.healthBarImage = healthBarImage[1];
    }
}
