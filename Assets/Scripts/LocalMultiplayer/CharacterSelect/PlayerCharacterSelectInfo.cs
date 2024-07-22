using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterSelectInfo
{
    public PlayerCharacterSelectInfo(PlayerInput playerInput) 
    {
        this.playerIndex = playerInput.playerIndex;
        this.playerInput = playerInput;

        Debug.Log("Hello thingy" + playerInput.currentControlScheme);
        this.playerControlScheme = playerInput.currentControlScheme;
        this.playerInputDevice = playerInput.devices[0];
    }

    PlayerInput playerInput { get; set; }
    public int playerIndex { get; set; }
    public bool isReady { get; set; }

    public string playerControlScheme {  get; set; }

    public InputDevice playerInputDevice { get; set; }

    public GameObject characterPrefab { get; set; }
}
