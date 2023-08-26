using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject backButton;
    public GameObject[] background;

    public string NextScene;

    int index;

    void Start()
    {
        index = 0;

        if (Input.GetJoystickNames().Length > 0)
            EventSystem.current.SetSelectedGameObject(nextButton);
    }

    void Update()
    {
        if (index >= 4)
            index = 4;

        if (index < 0)
            index = 0;

        if (index == 0)
        {
            background[0].gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1;

        if (index > 0)
        {
            background[index - 1].gameObject.SetActive(false);
        }

        backButton.gameObject.SetActive(true);

        if (index <= background.Length - 1)
        {
            background[index].gameObject.SetActive(true);
        }
        else
        {
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            SceneManager.LoadScene(NextScene);
        }
    }


    public void Previous()
    {
        index -= 1;
        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }

        if (index <= 0)
        {
            backButton.gameObject.SetActive(false);
            EventSystem.current.SetSelectedGameObject(nextButton);
        }
    }
}



