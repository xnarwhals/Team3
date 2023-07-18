using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [Tooltip("check to start from right, uncheck for right")]
    public bool startFromRight;

    [Tooltip("distance from center that drone will stay at (for both sides)")]
    public float switchDist = 6.0f;
    [Tooltip("how long it takes to get from one side to the other")]
    public float switchTime = 1.0f;
    [Tooltip("how long the drone waits before switching sides")]
    public float stayWaitTime = 10.0f;


    Rigidbody2D rb;

    bool doSwitch = false;
    bool isOnRight;
    float switchDest; //just switchDest but positive or negative depending on isOnRight

    float stayTimer = 0.0f;
    float switchVel = 0.0f;
    Vector3 switchOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stayTimer += Time.deltaTime;
        if (stayTimer >= stayWaitTime)
        {
            EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitchStart { drone = gameObject }); //for sound fx

            updateSwitchVars();
            doSwitch = true;
        }

        if (doSwitch) switchSides();
    }

    void switchSides() //runs in update (during switching)
    {
        if (!reachedDest())
        {
            /*float newPos = Mathf.Lerp(transform.position.x, switchDest, Time.deltaTime);
            transform.position = new Vector2(newPos, transform.position.y);*/

            //print(newPos);
        }
        else
        {
            EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitchDone { drone = gameObject }); //for sound fx
        }

        bool reachedDest() //fill out
        {
            if (isOnRight)
            {
                return transform.position.x <= switchDest;
            }
            else
            {
                return transform.position.x >= switchDest;
            }
        }
    }

    void updateSwitchVars()
    {
        switchOrigin = transform.position;
        isOnRight = transform.position.x > 0.0f; //dependent on x = 0 being center of screen
        switchDest = switchDist;
        if (isOnRight) { switchDest *= -1.0f; } //make the destination on left(negative) if on left
    }
}
