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

    public AudioSource textAudioSource; // Trying to make a sound effect play with every word being written in front of the player

    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EndDialogue>(CloseDialogue);
    }

    void Update()
    {
        if (!dialogueOpen)
        {
            if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.E)) // Interact button
            {
                OpenDialogue(dialogueLines[currentIndex]);
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.D)) // Right arrow
            {
                currentIndex++;
                if (currentIndex > marketSprites.Length - 1) currentIndex = 0;
                UpdateBackground();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button2) || Input.GetKeyUp(KeyCode.A)) // Left arrow
            {
                currentIndex--;
                if (currentIndex < 0) currentIndex = marketSprites.Length - 1;
                UpdateBackground();
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
        dialogueOpen = false;
    }

    void UpdateBackground()
    {
        MarketImage.sprite = marketSprites[currentIndex];
    }
}
