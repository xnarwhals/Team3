// Ignore Spelling: pfp
// Ignore Spelling: evt

using EvtSystem;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameEvents;

public class DialogueSystem : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;

    public GameObject pfp;
    public GameObject[] activate; //very temp
    public GameObject continueIcon;

    public GameObject color1;
    public GameObject color2;

    MarketDialogue currentDialogue;
    int currentIndex = 0;

    public TMPro.TextMeshProUGUI dialogueText;
    StringReveal typewriter = new StringReveal();

    [Tooltip("characters per second")]
    public float dialogueSpeed = 0.1f;

    bool dialogueOverStandby = false;

    // Start is called before the first frame update
    void Start()
    {
        EventDispatcher.AddListener<StartDialogue>(BeginDialogue);
        EventDispatcher.AddListener<ContinueDialogue>(BeginDialogue);

        Time.timeScale = 1.0f;
    }

    private void OnDestroy()
    {
        EventDispatcher.RemoveListener<StartDialogue>(BeginDialogue);
        EventDispatcher.RemoveListener<ContinueDialogue>(BeginDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (typewriter.hasStarted())
        {
            if (!typewriter.isDone())
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.E)
                    && typewriter.GetCurrentRevealedText().Length > 0)  //fixes a bug using duct tape
                {
                    typewriter.ForceFinish();
                    dialogueText.text = typewriter.GetCurrentRevealedText();
                }
                else
                {
                    dialogueText.text = typewriter.GetCurrentRevealedText();
                }
            }
            else
            {
                if (!dialogueOverStandby)
                {
                    dialogueOverStandby = true;
                    
                    currentIndex++;
                    DialogueEnd();
                }

                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.E)) 
                {
                    ContinueDialogue evt = new ContinueDialogue();
                    evt.dialogueLine = currentDialogue;
                    evt.index = currentIndex;

                    EventDispatcher.Raise(evt);
                }
            }
        }
    }

    public void BeginDialogue(StartDialogue evt)
    {
        dialogueOverStandby = false;

        currentDialogue = evt.dialogueLine;
        currentIndex = evt.index;
        float duration = currentDialogue.lines[evt.index].Length / dialogueSpeed;

        typewriter.StartReveal(currentDialogue.lines[evt.index], duration);


        pfp.SetActive(true);
        pfp.GetComponent<Image>().sprite = currentDialogue.CloseUp;

        activate[0].SetActive(true);
        continueIcon.SetActive(false);
    }

    public void BeginDialogue(ContinueDialogue evt) //this is so messy but it works
    {
        dialogueOverStandby = false;

        currentDialogue = evt.dialogueLine;
        currentIndex = evt.index;
        float duration = currentDialogue.lines[evt.index].Length / dialogueSpeed;

        typewriter.StartReveal(currentDialogue.lines[evt.index], duration);


        pfp.SetActive(true);
        pfp.GetComponent<Image>().sprite = currentDialogue.CloseUp;

        activate[0].SetActive(true);
        continueIcon.SetActive(false);
    }

    void DialogueEnd()
    {
        if (currentDialogue.lines.Length > currentIndex)
        {
            ContinueDialogue();
        }
        else
        {
            dialogueOverStandby = false;
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
        EventSystem.current.SetSelectedGameObject(button2);

        activate[1].SetActive(true);
        activate[2].SetActive(true);

        continueIcon.SetActive(false);

        Image img1 = color1.GetComponent<Image>();
        img1.color = currentDialogue.color1;

        Image img2 = color2.GetComponent<Image>();
        img2.color = currentDialogue.color2;
    }

    public void Choose()
    {
        //PlayerPrefs.SetInt("Color1", currentDialogue.color1);
        //PlayerPrefs.SetInt("Color2", currentDialogue.color2);

        Loader.Load("OfficialHowToPlay");
        Destroy(gameObject);
    }
    
    public void Back()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        pfp.SetActive(false);

        activate[0].SetActive(false);
        activate[1].SetActive(false);
        activate[2].SetActive(false);

        dialogueText.text = "";

        EventDispatcher.Raise(new EndDialogue());
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
