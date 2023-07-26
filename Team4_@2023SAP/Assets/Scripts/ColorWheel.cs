using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorWheel : MonoBehaviour
{
    public Sprite[] sprites;

    int currentIndex;

    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
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
                currentIndex = (int)(Vector2.Angle(Vector2.left, stickPos) / 180.0f * (sprites.Length - 1));
                img.sprite = sprites[currentIndex];

                FindAnyObjectByType<PaintExample>().brush.splatChannel = currentIndex;
            }
        }
        else
        {
            img.enabled = false;
        }
    }
}
