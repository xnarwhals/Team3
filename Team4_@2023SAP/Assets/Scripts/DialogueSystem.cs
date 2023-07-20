// Ignore Spelling: pfp
// Ignore Spelling: evt

using EvtSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameEvents;

public class DialogueSystem : Singleton<DialogueSystem>
{
    public GameObject button1;
    public GameObject button2;

    public GameObject pfp;
    public GameObject[] activate; //very temp
    public GameObject continueIcon;

    MarketDialogue currentDialogue;
    int currentIndex = 0;

    public TMPro.TextMeshProUGUI dialogueText;
    StringReveal typewriter = new StringReveal();

    [Tooltip("characters per second")]
    public float dialogueSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        EventDispatcher.AddListener<StartDialogue>(BeginDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (typewriter.hasStarted())
        {
            if (!typewriter.isDone())
            {
                if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.Return)
                    && typewriter.GetCurrentRevealedText().Length > 0)  //fixes a bug using duct tape
                {
                    typewriter.ForceFinish();
                    dialogueText.text = typewriter.GetCurrentRevealedText();
                    DialogueEnd();
                }
                else
                {
                    dialogueText.text = typewriter.GetCurrentRevealedText();
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.Return)) 
                {
                    StartDialogue evt = new StartDialogue();
                    evt.dialogueLine = currentDialogue;
                    evt.index = currentIndex;

                    EventDispatcher.Raise(evt);
                }
            }
        }
    }

    //just putting this in start for now
    public void BeginDialogue(StartDialogue evt)
    {
        pfp.SetActive(true);
        activate[3].SetActive(true);

        currentDialogue = evt.dialogueLine;
        currentIndex = evt.index;
        float duration = currentDialogue.lines[evt.index].Length / dialogueSpeed;

        typewriter.StartReveal(currentDialogue.lines[evt.index], duration);
    }

    void DialogueEnd()
    {
        currentIndex++;
        if (currentDialogue.lines.Length > currentIndex)
        {
            ContinueDialogue();
        }
        else
        {
            ShowButtons();
        }
    }

    void ContinueDialogue()
    {
        continueIcon.SetActive(true);
    }

    void ShowButtons()
    {
        currentIndex = 0;
        typewriter.textToReveal = null;

        button1.SetActive(true);
        button2.SetActive(true);

        activate[0].SetActive(true);
        activate[1].SetActive(true);
        activate[2].SetActive(true);
    }

    //the button on the top is 0 and the bottom is 1
    public void Choose()
    {
        //open level
    }

    public void Back()
    {

    }

    class StringReveal
    {
        public string textToReveal = null;

        float currentTime;
        float secondsPerChar;
        int currentStringIndex = 0;

        public void StartReveal(string text, float duration)
        {
            secondsPerChar = duration / text.Length;
            textToReveal = text;

            currentStringIndex = 0;
            currentTime = 0.0f;
        }

        public bool hasStarted()
        {
            return textToReveal != null;
        }

        public bool isDone()
        {
            return textToReveal == null || currentStringIndex == textToReveal.Length;
        }

        public void ForceFinish()
        {
            currentStringIndex = textToReveal.Length;
            currentTime = 0.0f;
        }

        public string GetCurrentRevealedText()
        {
            currentTime += Time.deltaTime;

            if (currentTime >= secondsPerChar && currentStringIndex < textToReveal.Length)
            {
                currentStringIndex++;
                currentTime = 0.0f;
            }

            return textToReveal.AsSpan(0, currentStringIndex).ToString();
        }
    }
}
