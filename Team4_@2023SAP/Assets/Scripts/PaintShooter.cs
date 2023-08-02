using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintShooter : MonoBehaviour
{
    public float fireRate = 0.1f;

    float fireTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton0)) 
            && fireTimer >= fireRate)
        {
            fireTimer = 0;

            EvtSystem.EventDispatcher.Raise(new GameEvents.ShootPaint());
        }
    }
}
