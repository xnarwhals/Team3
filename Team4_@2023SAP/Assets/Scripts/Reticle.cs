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
    }

    public void Update()
    {
        Vector2 stickPos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 desiredPos = (Vector2)transform.position + (2* stickPos);

        transform.position = Vector2.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
    }
}
