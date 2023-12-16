using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : SingletonLite<Reticle>
{
    public float speed;
    public float ControllerSpeedMulti = 0.5f;

    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Cursor.visible = false;

        /*if (Input.GetJoystickNames().Length <= 0)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }*/
    }

    bool input = true; //true is controller, false is keyboard
    Vector3 PrevMousePos = Vector2.zero;
    public void Update()
    {
        Vector2 stickPos =
                new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.mousePosition != PrevMousePos)
        {
            PrevMousePos = Input.mousePosition;
            input = false;
        }
        else if (stickPos.magnitude >= 0.1f)
        {
            input = true;
        }

        Vector2 desiredPos;
        if (input)
        {
            stickPos =
                new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            desiredPos = (Vector2)transform.position + (2.0f * stickPos);
        }
        else
        {
            desiredPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        float multi = input ? ControllerSpeedMulti : 1.0f;

        transform.position = Vector2.Lerp
                (transform.position, desiredPos, Time.deltaTime * speed * multi);

        float x = Mathf.Clamp(transform.position.x, 
            Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x,
            Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.scaledPixelWidth, 0.0f, 0.0f)).x);

        float y = Mathf.Clamp(transform.position.y, 
            Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y,
            Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Camera.main.scaledPixelHeight, 0.0f)).y);
        transform.position = new Vector2(x, y);
    }
}

