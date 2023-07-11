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

    float switchTimer = 0.0f;
    float stayTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isOnRight = startFromRight;
        switchDest = switchDist;
        if (isOnRight) { switchDest *= -1.0f; } //make the destination on left(negative) if on left
    }

    // Update is called once per frame
    void Update()
    {
        stayTimer += Time.deltaTime;
        if (stayTimer >= stayWaitTime)
        {
            EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitch { drone = gameObject }); //for sound fx

            doSwitch = true;
        }

        if (doSwitch) switchSides();
    }

    void switchSides() //runs in update (during switching)
    {
        if (!reachedDest())
        {
            switchTimer += Time.deltaTime;

            Vector2 targetPos = new Vector2(switchDest, transform.position.y);

            Vector2 newPos = Vector2.Lerp(transform.position, targetPos, switchTimer / switchTime);
            transform.position = newPos;
        }
        else
        {
            //update all variables
        }

        bool reachedDest() //fill out
        {
            return false;
        }
    }
}
