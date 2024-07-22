using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class DialogueCharacter
{
    public string characterName;
    [TextArea(3,10)]
    public string dialogueLine;
    public AudioSource voiceLine;
    public CinemachineVirtualCamera newCamera;
    public StoryModeMovement storyModeMovement;
    public PlayableDirector timelineAnimation;
}
