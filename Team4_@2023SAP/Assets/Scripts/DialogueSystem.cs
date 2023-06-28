using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;

    // Start is called before the first frame update
    void Start()
    {
        BeginDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //if ()//input X
    }

    //just putting this in start for now
    void BeginDialogue()
    {

    }

    void ShowButtons()
    {
        button1.SetActive(true);
        button2.SetActive(true);
    }

    //the button on the top is 0 and the bottom is 1
    public void ButtonClicked(int button)
    {
        //gameManager.setColors(button); //calling fake functions of what will go on 
        //sceneManager.loalNextLevel();  //once we have all those managers
    }

    class StringReveal
    {
        string textToReveal = null;

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

        public bool isDone()
        {
            return (textToReveal == null || currentStringIndex == textToReveal.Length);
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
