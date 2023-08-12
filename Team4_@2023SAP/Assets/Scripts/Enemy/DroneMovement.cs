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
    public float scanTime = 1.0f;

    [SerializeField] float ScanPower = 10;

    [HideInInspector]
    public Vector2 target;

    public float sizeMulti = 1.2f;

    Animator animator;


    float stayTimer = 0.0f;
    float scanTimer = 0.0f;

    Vector2 dampVel = Vector2.zero;

    bool tempflagForDeath = false;

    EnemyHealth healthScript;

    enum Mode
    {
        move,
        idle,
        scan,
        death
    }

    Mode _mode = Mode.move;
    Mode mode
    {
        get { return _mode; }
        set 
        { 
            _mode = value;

            animator.SetInteger("State", (int)_mode);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempflagForDeath) mode = Mode.death;

        switch (mode)
        {
            case Mode.move:
                updateMove();
                break;

            case Mode.idle:
                stayTimer += Time.deltaTime;
                if (stayTimer >= stayWaitTime)
                {
                    stayTimer = 0;

                    EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitchStart { drone = gameObject }); //for sound fx

                    startScan();
                }
                break;

            case Mode.scan:
                
                break;
        }
    }

    void updateMove() //runs in update (during switching)
    {
        if (!reachedDest())
        {
            transform.position = Vector2.SmoothDamp(transform.position, target, 
                ref dampVel, switchTime);
        }
        else
        {
            finishMove();

            EvtSystem.EventDispatcher.Raise(new GameEvents.DroneSwitchDone { drone = gameObject }); //for sound fx
        }

        bool reachedDest() //fill out
        {
            return ((Vector2)transform.position - target).sqrMagnitude < 0.01f;
        }
    }

    void finishMove()
    {
        mode = Mode.idle;

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

    void startScan()
    {
        mode = Mode.scan;
    }

    public void finishScan()
    {
        EvtSystem.EventDispatcher.Raise<GameEvents.ScanComplete>(new GameEvents.ScanComplete());
        GameManager.gameManager.playerIdentity.IdentityLose(ScanPower);

        mode = Mode.move;
    }

    public void Die(EnemyHealth health)
    {
        if (mode == Mode.scan) tempflagForDeath = true;
        mode = Mode.death;
        GetComponent<Collider2D>().enabled = false;

        transform.localScale *= sizeMulti;
    }

    public void FinishDie()
    {
        Destroy(gameObject);
    }
}
