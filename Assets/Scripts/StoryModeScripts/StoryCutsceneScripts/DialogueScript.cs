using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using Cinemachine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DialogueScript : MonoBehaviour
{
    public Boolean dialogueEnded = false;
    public TextMeshProUGUI dialogueComponent;
    public TextMeshProUGUI characterName;

    public CinemachineVirtualCamera[] virtualCameraList;
    public CinemachineVirtualCamera startingCamera;
    private CinemachineVirtualCamera currentCamera;

    private InputActionAsset inputAsset;
    private InputActionMap storyModeNavigation;


    public float textSpeed;
    private int dialogueIndex;

    public List<DialogueCharacter> dialogueSequence = new List<DialogueCharacter>();

    private string sceneName;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        storyModeNavigation = inputAsset.FindActionMap("StoryModeNavigation");
    }


    // Start is called before the first frame update
    void Start()
    {
        currentCamera = startingCamera;
        dialogueComponent.text = string.Empty;
        StartDialogue();
    }
    
    // Update is called once per frame
    void Update()
    {
 /*       if (Input.GetMouseButtonDown(0))
        {
            if ((dialogueComponent.text == dialogueSequence[dialogueIndex].dialogueLine) && (characterName.text == dialogueSequence[dialogueIndex].characterName))
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueComponent.text = dialogueSequence[dialogueIndex].dialogueLine;
                characterName.text = dialogueSequence[dialogueIndex].characterName;
            }
        }*/
    }

    void StartDialogue()
    {
        dialogueIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (dialogueSequence[dialogueIndex].storyModeMovement != null)
        {
            dialogueSequence[dialogueIndex].storyModeMovement.MoveCharacter();
        }

        if(currentCamera != dialogueSequence[dialogueIndex].newCamera)
        {
            currentCamera = dialogueSequence[dialogueIndex].newCamera;
            SwitchCamera(currentCamera);
        }

        if (dialogueSequence[dialogueIndex].timelineAnimation != null)
        {
            dialogueSequence[dialogueIndex].timelineAnimation.Play();
        }


        characterName.text = dialogueSequence[dialogueIndex].characterName;
        foreach (char c in dialogueSequence[dialogueIndex].dialogueLine.ToCharArray())
        {
            dialogueComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (dialogueIndex < dialogueSequence.Count - 1)
        {
            dialogueIndex++;
            dialogueComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void SwitchCamera(CinemachineVirtualCamera targetCamera)
    {
      foreach (CinemachineVirtualCamera virtualCamera in virtualCameraList)
        {
            virtualCamera.enabled = virtualCamera == targetCamera;
        }
    }

    private void OnEnable()
    {
        storyModeNavigation.FindAction("ContinueStoryDialogue").started += OnContinueStoryDialogue;
        storyModeNavigation.FindAction("SkipStoryDialogue").started += OnSkipStoryDialogue;
    }


    private void OnContinueStoryDialogue(InputAction.CallbackContext context)
    {
        if ((dialogueComponent.text == dialogueSequence[dialogueIndex].dialogueLine) && (characterName.text == dialogueSequence[dialogueIndex].characterName))
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueComponent.text = dialogueSequence[dialogueIndex].dialogueLine;
            characterName.text = dialogueSequence[dialogueIndex].characterName;
        }
    }

    private void OnSkipStoryDialogue(InputAction.CallbackContext context)
    {
        StopAllCoroutines();
        EndDialogue();
    }


    void EndDialogue()
    {
        dialogueEnded = true;
        string activeSceneName = SceneManager.GetActiveScene().name;

        switch (activeSceneName)
        {
            case "StoryCutsceneOne":
                sceneName = "StoryModeBattleOne";
                break;

            case "StoryCutsceneTwo":
                sceneName = "StoryCutsceneThree";
                break;
            case "StoryCutsceneThree":
                sceneName = "StoryModeBattleTwo";
                break;
            default: 
                break;
        }
        SceneManager.LoadScene(sceneName);
    }
}
