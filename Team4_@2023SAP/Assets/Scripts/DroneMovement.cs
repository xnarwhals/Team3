using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [Tooltip("how long it takes to get from one side to the other")]
    public float switchTime = 1.0f;
    [Tooltip("how long the drone waits before switching sides")]
    public float stayWaitTime = 10.0f;

    [DoNotSerialize]
    public Transform target;

    Rigidbody2D rb;

    bool doSwitch = false;

    float stayTimer = 0.0f;
    Vector2 dampVel = Vector2.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!doSwitch)
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= stayWaitTime)
            {
                stayTimer = 0;

                EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitchStart { drone = gameObject }); //for sound fx

                updateSwitchVars();
                doSwitch = true;
            }
        }
        else
        {
            switchSides();
        }
    }

    void switchSides() //runs in update (during switching)
    {
        if (!reachedDest())
        {
            transform.position = Vector2.SmoothDamp(transform.position, target.position, 
                ref dampVel, switchTime);
        }
        else
        {
            doSwitch = false;

            EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitchDone { drone = gameObject }); //for sound fx
        }

        bool reachedDest() //fill out
        {
            return (transform.position - target.position).sqrMagnitude < 0.01f;
        }
    }

    void updateSwitchVars()
    {
        target.position = new Vector2(Random.Range(-8, 8), Random.Range(-2.9f, 3f));
    }
}
