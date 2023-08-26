using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
        if (Joystick.current.IsUnityNull())
        {
            img.sprite = Controller;
        }
        else
        {
            try { img.sprite = Keyboard; } 
            catch 
            {
                img.color = new Color(0, 0, 0, 0);
            }
        }
    }
}
