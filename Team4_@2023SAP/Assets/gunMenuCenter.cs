using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gunMenuCenter : MonoBehaviour
{
    public float offset = -90.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 stickPos = new Vector2(Input.GetAxis("ColorWheelX"), Input.GetAxis("ColorWheelY"));
        if (stickPos.magnitude > 0.05f)
        {
            float theta = Mathf.Atan(stickPos.y / stickPos.x) * Mathf.Rad2Deg;
            if (stickPos.x < 0) theta += 180.0f;

            theta += offset;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, theta);
        }
    }
}
