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

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        paintScript = FindAnyObjectByType<PaintExample>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("OpenColorWheel") == 1 || Input.GetKey(KeyCode.I))
        {
            img.enabled = true;

            Vector2 stickPos = new Vector2(Input.GetAxis("ColorWheelX"), Input.GetAxis("ColorWheelY"));
            if (stickPos.magnitude > 0.1f && stickPos.y >= 0.0f)
            {
                currentIndex = (int)((Vector2.Angle(Vector2.left, stickPos) + offset) / 180.0f * (sprites.Length - 1));
                img.sprite = sprites[currentIndex];

                paintScript.brush.splatChannel = currentIndex;

                if (currentIndex != prevIndex)
                {
                    EvtSystem.EventDispatcher.Raise(new GameEvents.ColorWheelChange());
                    print("wh");
                }

                prevIndex = currentIndex;
            }
        }
        else
        {
            img.enabled = false;
        }
    }
}
