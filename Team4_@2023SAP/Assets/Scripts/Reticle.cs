using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : Singleton<Reticle>
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
        if (Input.GetJoystickNames().Length > 0)
        {
            Vector2 stickPos = 
                new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 desiredPos = (Vector2)transform.position + (2.0f * stickPos);

            transform.position = 
                Vector2.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
        }
        else
        {
            Vector2 desiredPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = Vector2.Lerp
                (transform.position, desiredPos, Time.deltaTime * speed);
        }
    }
}
