using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorWheel : MonoBehaviour
{
    public Sprite[] sprites;
    public float offset = 0.0f;

    int prevIndex;
    int currentIndex;

    PaintExample paintScript;
    Image img;

    GameObject center;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        paintScript = FindAnyObjectByType<PaintExample>();
        center = FindAnyObjectByType<gunMenuCenter>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            OpenMenu(0);
        }
        else if (Input.GetKey("2"))
        {
            OpenMenu(1);
        }
        else if (Input.GetKey("3"))
        {
            OpenMenu(2);
        }
        else if (Input.GetKey("4"))
        {
            OpenMenu(3);
        }
        else
        {
            img.enabled = false;
        }

        if (Input.GetAxis("OpenColorWheel") == 1)
        {
            img.enabled = true;
            center.SetActive(true);

            Vector2 stickPos = new Vector2(Input.GetAxis("ColorWheelX"), Input.GetAxis("ColorWheelY"));
            if (stickPos.magnitude > 0.1f && stickPos.y >= 0.0f)
            {
                currentIndex = (int)((Vector2.Angle(Vector2.left, stickPos) + offset) / 180.0f * (sprites.Length - 1));
                OpenMenu(currentIndex);
            }
        }
        else
        {
            center.SetActive(false);
        }
    }

    void OpenMenu(int index)
    {
        img.enabled = true;

        img.sprite = sprites[index];

        paintScript.brush.splatChannel = index;

        if (index != prevIndex)
        {
            EvtSystem.EventDispatcher.Raise(new GameEvents.ColorWheelChange { ChangedColor = index });
        }

        prevIndex = index;
    }
}
