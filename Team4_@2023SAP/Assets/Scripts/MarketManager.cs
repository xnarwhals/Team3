using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public Image MarketImage;
    public Sprite[] marketSprites;
    public MarketDialogue[] dialogueLines;

    int currentIndex = 0;
    bool dialogueOpen;

    public float DialogueSpeed = 5.0f; // I want to be able to edit this, but I do not know where to tell of this change in the code  

    public AudioClip textAudioClip; // Trying to make a sound effect play with every word being written in front of the player

    float thumbStickDeadzone = 0.9f;

    int joystickDirection = -1;

    bool postClose = false;

    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EndDialogue>(CloseDialogue);
    }

    private void OnDestroy()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EndDialogue>(CloseDialogue);
    }

    void Update()
    {
        if (!dialogueOpen)
        {
            if (joystickDirection == -1)
            {
                if (Input.GetAxis("Horizontal") > thumbStickDeadzone)
                {
                    joystickDirection = 1;
                }
                else if (Input.GetAxis("Horizontal") < -thumbStickDeadzone)
                {
                    joystickDirection = 0;
                }
            }
            else if (joystickDirection == -2 && Mathf.Abs(Input.GetAxis("Horizontal")) < thumbStickDeadzone)
            {
                joystickDirection = -1;
            }
            else
            {
                joystickDirection = -2;
            }

            if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.E)) // Interact button
            {
                OpenDialogue(dialogueLines[currentIndex]);
            }
            else if (joystickDirection == 1 || 
                Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) // Right arrow
            {
                currentIndex++;
                if (currentIndex > marketSprites.Length - 1) currentIndex = 0;
                UpdateBackground();
            }
            else if (joystickDirection == 0 || 
                Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) // Left arrow
            {
                currentIndex--;
                if (currentIndex < 0) currentIndex = marketSprites.Length - 1;
                UpdateBackground();
            }
        }
        else if (postClose)
        {
            if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.E))
            {
                dialogueOpen = false;
                postClose = false;
            }
        }
    }

    void OpenDialogue(MarketDialogue dialogueLine)
    {
        GameEvents.StartDialogue evt = new GameEvents.StartDialogue();
        evt.dialogueLine = dialogueLine;

        EvtSystem.EventDispatcher.Raise(evt);
        dialogueOpen = true;
    }

    void CloseDialogue(GameEvents.EndDialogue evt)
    {
        postClose = true;
    }

    void UpdateBackground()
    {
        MarketImage.sprite = marketSprites[currentIndex];
    }
}
