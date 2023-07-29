using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject controlCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (!controlCanvas.activeInHierarchy)
            {
                if (!mainCanvas.activeInHierarchy)
                {
                    PauseGame();
                }
                else
                {
                    ContinueClicked(); //does the same thing as the button
                }
            }
            else
            {
                Back();
            }
        }
    }

    public void PauseGame()
    {
        mainCanvas.SetActive(true);
        Time.timeScale = 0.0f;

        Cursor.visible = true;
    }

    public void ContinueClicked()
    {
        mainCanvas.SetActive(false);
        Time.timeScale = 1.0f; //if we do bullet time, change this!

        Cursor.visible = false;
    }

    public void RestartClicked()
    {
        //scene things most likely
    }

    public void ControlsClicked()
    {
        mainCanvas.SetActive(false);
        controlCanvas.SetActive(true);
    }

    public void ExitClicked()
    {
        //scene things
    }

    public void Back()
    {
        mainCanvas.SetActive(true);
        controlCanvas.SetActive(false);
    }
}
