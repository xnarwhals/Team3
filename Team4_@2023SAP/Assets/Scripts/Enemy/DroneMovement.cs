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

    [SerializeField] IdentityChangeUI identityBar;
    [SerializeField] float ScanPower = 10;

    [HideInInspector]
    public Vector2 target;

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

                doSwitch = true;
                Scan();
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
            transform.position = Vector2.SmoothDamp(transform.position, target, 
                ref dampVel, switchTime);
        }
        else
        {
            doSwitch = false;
            updateSwitchVars();

            EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitchDone { drone = gameObject }); //for sound fx
        }

        bool reachedDest() //fill out
        {
            return ((Vector2)transform.position - target).sqrMagnitude < 0.01f;
        }
    }

    void updateSwitchVars()
    {
        Vector2[,] grid = GameGrid.Instance.tiles;

        Vector2 newTarget = new Vector2();
        bool exit = false;
        while (exit == false)
        {
            newTarget = grid[Random.Range(0, grid.GetLength(0)), GetComponent<EnemySpawn>().spawnRow];
            if (newTarget != target && newTarget != grid[0, 0] && newTarget != grid[grid.GetLength(0) - 1, 0])
            {
                exit = true;
            }
        }

        target = newTarget;
    }

    void Scan()
    {
        GameManager.gameManager.playerIdentity.IdentityLose(ScanPower);
        identityBar.SetIdentity(GameManager.gameManager.playerIdentity.Identity);
    }
}
