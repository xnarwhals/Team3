using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrompt : MonoBehaviour
{
    public Sprite Keyboard;
    public Sprite Controller;

    // Start is called before the first frame update
    void Start()
    {
        SelectImage();
    }

    public void SelectImage()
    {
        Image img = GetComponent<Image>();
        if (Input.GetJoystickNames().Length > 0)
        {
            img.sprite = Controller;
        }
        else
        {
            img.sprite = Keyboard;
        }
    }
}
