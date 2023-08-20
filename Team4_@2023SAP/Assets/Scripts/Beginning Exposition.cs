using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Being able to edit the next mesh pro through the code

public class BeginningExposition : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences; // Will hold all the sentences that hold our dialogue
    private int index;
    public float typingSpeed = 0.1f;
    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true); // When the sentence is done, showcase the continue button
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index <= sentences.Length - 1) // Make sure we have not come to the end of our dialogue
        {
            index++; // of 1
            textDisplay.text = ""; // To prevent sentences to stack
            StartCoroutine(Type()); // A new sentence slowly displays itself
        }
        else
        {
            textDisplay.text = ""; // Resets the text
            continueButton.SetActive(false);
        }
    }
}

