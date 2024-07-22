using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInstantiater : MonoBehaviour
{
    [SerializeField]
    public CharacterSelectionManager characterSelectionManager;
    PlayerInputManager playerInputManager;

    [SerializeField]
    public List<PlayerInput> players = new List<PlayerInput>();

    [SerializeField]
    public List<Image> healthBarImage = new List<Image>();

    private void Awake()
    {
        characterSelectionManager = FindObjectOfType<CharacterSelectionManager>();
        playerInputManager = characterSelectionManager.GetComponent<PlayerInputManager>();
        if( playerInputManager != null)
        {
            PlayerCharacterSelectInfo player1CharSelectInfo = characterSelectionManager.playerCharSelectInfos[0];
            PlayerCharacterSelectInfo player2CharSelectInfo = characterSelectionManager.playerCharSelectInfos[1];

            //HardCoded instantiation for fixed control scheme
            var player1 = PlayerInput.Instantiate(player1CharSelectInfo.characterPrefab, controlScheme: player1CharSelectInfo.playerControlScheme, pairWithDevice: player1CharSelectInfo.playerInputDevice);
            var player2 = PlayerInput.Instantiate(player2CharSelectInfo.characterPrefab, controlScheme: player2CharSelectInfo.playerControlScheme, pairWithDevice: player2CharSelectInfo.playerInputDevice);

            player1.GetComponent<HealthBar>().enabled = true;
            player2.GetComponent<HealthBar>().enabled= true;
            HealthBar player1HealthBar = player1.GetComponent<HealthBar>();
            HealthBar player2HealthBar = player2.GetComponent<HealthBar>();
            player1HealthBar.healthBarImage = healthBarImage[0];
            player2HealthBar.healthBarImage = healthBarImage[1];


            players.Add(player1);
            players.Add(player2);
        }
    }

}
