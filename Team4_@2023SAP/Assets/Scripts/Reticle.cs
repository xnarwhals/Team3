using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : SingletonLite<Reticle>
{
    public float speed;

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

    public void Update()
    {
        Vector2 desiredPos;
        if (Input.GetJoystickNames().Length > 0)
        {
            Vector2 stickPos =
                new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            desiredPos = (Vector2)transform.position + (2.0f * stickPos);
        }
        else
        {
            desiredPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector2.Lerp
                (transform.position, desiredPos, Time.deltaTime * speed);

        float x = Mathf.Clamp(transform.position.x, 
            Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x,
            Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.scaledPixelWidth, 0.0f, 0.0f)).x);

        float y = Mathf.Clamp(transform.position.y, 
            Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y,
            Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Camera.main.scaledPixelHeight, 0.0f)).y);
        transform.position = new Vector2(x, y);
    }
}

