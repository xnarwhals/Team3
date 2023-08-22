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

    private AudioSource textAudioSource; // Trying to make a sound effect play with every word being written in front of the player

    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EndDialogue>(CloseDialogue);

        textAudioSource = transform.Find("Pan14 - Tone Beep").GetComponent<AudioSource>(); // When the scene starts, find this audio
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

    private void StartTalkingSound() // When dialogue plays out, I want you to play
    {
        textAudioSource.Play();
    }

    private void StopTalkingSound() // When the very last word is typed out, I want you to stop
    {
        textAudioSource.Play();
    }
}
