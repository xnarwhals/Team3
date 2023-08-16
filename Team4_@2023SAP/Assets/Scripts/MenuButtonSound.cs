using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonSound : MonoBehaviour
{
    public AudioSource specificButton;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        specificButton.PlayOneShot(hoverSound);
    }
    public void ClickSound()
    {
        specificButton.PlayOneShot(clickSound);
    }
}
