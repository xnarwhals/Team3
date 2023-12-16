﻿// Ignore Spelling: evt

using EvtSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintExample : SingletonLite<PaintExample>
{
    public Brush brush;
    public bool SingleShotClick = false;
    public bool IndexBrush = false;
    public float PaintUseFreeze = 0.1f;

    float PaintUseFreezeTimer = 0.0f;

    //Change Paint Variables 
    [SerializeField] [Range(1f, 45f)] float paintCost;
    [SerializeField] [Range(1f, 45f)] public float paintRegenSpeed;
    [SerializeField] [Range(0.1f, 10f)] float regenMultiplier;
    bool isRegening = true;
    bool color = false;
    int[] colors = new int[2];

    public float currentRegenSpeed;

    //Refrence to the Bar 
    [SerializeField] PaintChangeUI paintBar;
    [SerializeField] GameManager _gameManager; 

    private Texture2D colorTex;

    private bool canPaint = true;
    private bool isDead;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        EvtSystem.EventDispatcher.AddListener<GameEvents.NoPaintMouseOver>(UpdateNoPaint);
        EvtSystem.EventDispatcher.AddListener<GameEvents.ShootPaint>(Shoot);

        colorTex = new Texture2D(1, 1);

        if (brush.splatTexture == null)
        {
            brush.splatTexture = Resources.Load<Texture2D>("splats");
            brush.splatsX = 4;
            brush.splatsY = 4;
        }

        //colors[0] = PlayerPrefs.GetInt("Color1");
        //colors[1] = PlayerPrefs.GetInt("Color2");
    }

    private void OnDestroy()
    {
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ShootPaint>(Shoot);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.NoPaintMouseOver>(UpdateNoPaint);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) brush.splatChannel = 0;//orange
        if (Input.GetKeyDown(KeyCode.Alpha2)) brush.splatChannel = 1;//red
        if (Input.GetKeyDown(KeyCode.Alpha3)) brush.splatChannel = 2;//blue
        if (Input.GetKeyDown(KeyCode.Alpha4)) brush.splatChannel = 3;//green*/

        //Paint Regen 
        if (GameManager.gameManager.playerPaint.Paint <= 0 && isRegening)
        {
            isRegening = false;
            canPaint = false;
            currentRegenSpeed = paintRegenSpeed * regenMultiplier;
        }
        else if (GameManager.gameManager.playerPaint.Paint >= 100f)
        {
            isRegening = true;
            canPaint = true;
        }

        if (PaintUseFreezeTimer >= PaintUseFreeze)
        {
            PlayerRegenPaint();
        }
        else
        {
            PaintUseFreezeTimer += Time.deltaTime;
        }


        //Identity Loss
        if (_gameManager.playerIdentity.Identity >= 100 && !isDead)
        {
            isDead = true;
            canPaint = false;

            _gameManager.GameOver();
        }
    }

    void UpdateNoPaint(GameEvents.NoPaintMouseOver evt)
    {
        if (!canPaint)
        {
            return;
        }
        canPaint = !evt.isOver;
    }

    public void PlayerUsePaint(float paintAmount)
    {
        GameManager.gameManager.playerPaint.UsePaint(paintAmount);//updates data
        paintBar.SetPaint(GameManager.gameManager.playerPaint.Paint);//updates UI

        PaintUseFreezeTimer = 0.0f;
    }

    public void PlayerRegenPaint()
    {

        GameManager.gameManager.playerPaint.RegenPaint(currentRegenSpeed);//updates data
        paintBar.SetPaint(GameManager.gameManager.playerPaint.Paint);//updates UI
    }

    public void Shoot(GameEvents.ShootPaint evt)
    {
        currentRegenSpeed = paintRegenSpeed;
        PaintTarget.PaintCursor(brush, evt.position);
        PlayerUsePaint(paintCost);
        if (IndexBrush) brush.splatIndex++;
    }

    public float PaintEmptyTime = 0.2f;
    float PaintEmptyTimer = 0.0f;

    public bool CanPaint()
    {
        if (!canPaint && Time.time - PaintEmptyTimer > PaintEmptyTime)
        {
            PaintEmptyTimer = Time.time;

            EventDispatcher.Raise(new GameEvents.PaintEmpty());
        }

        return canPaint && _gameManager.playerPaint.Paint > 0 && isRegening && !isDead;
    }
}