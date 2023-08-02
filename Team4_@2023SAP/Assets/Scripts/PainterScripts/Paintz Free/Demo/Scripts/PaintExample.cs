using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintExample : Singleton<PaintExample>
{
    public Brush brush;
    public bool SingleShotClick = false;
    public bool IndexBrush = false;

    //Change Paint Variables 
    [SerializeField] [Range(1f, 45f)] float paintAmountUsed;
    [SerializeField] [Range(1f, 45f)] float paintRegenSpeed;
    [SerializeField] [Range(0.1f, 10f)] float regenMultiplier;
    bool isRegening = true;
    bool color = false;
    int[] colors = new int[2];

    float currentRegenSpeed;

    //Refrence to the Bar 
    [SerializeField] PaintChangeUI paintBar;
    [SerializeField] GameManager _gameManager; 

    private Texture2D colorTex;

    private bool canPaint = true;
    private bool isDead;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();

        EvtSystem.EventDispatcher.AddListener<GameEvents.NoPaintMouseOver>(UpdateNoPaint);

        colorTex = new Texture2D(1, 1);

        if (brush.splatTexture == null)
        {
            brush.splatTexture = Resources.Load<Texture2D>("splats");
            brush.splatsX = 4;
            brush.splatsY = 4;
        }

        colors[0] = PlayerPrefs.GetInt("Color1");
        colors[1] = PlayerPrefs.GetInt("Color2");
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) brush.splatChannel = 0;//orange
        if (Input.GetKeyDown(KeyCode.Alpha2)) brush.splatChannel = 1;//red
        if (Input.GetKeyDown(KeyCode.Alpha3)) brush.splatChannel = 2;//blue
        if (Input.GetKeyDown(KeyCode.Alpha4)) brush.splatChannel = 3;//green*/

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if(canPaint && _gameManager.playerPaint.Paint > 0 && isRegening && !isDead)
            {
                currentRegenSpeed = paintRegenSpeed;
                PaintTarget.PaintCursor(brush);
                PlayerUsePaint(paintAmountUsed);
                if (IndexBrush) brush.splatIndex++;
            }         
        }

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
        PlayerRegenPaint();

        //Identity Loss
        if (_gameManager.playerIdentity.Identity >= 100 && !isDead)
        {
            isDead = true;
            canPaint = false;

            Debug.Log("Gameover");
            _gameManager.GameOver();
        }
    }

    void UpdateNoPaint(GameEvents.NoPaintMouseOver evt)
    {
        canPaint = !evt.isOver;
    }

    public void PlayerUsePaint(float paintAmount)
    {
        GameManager.gameManager.playerPaint.UsePaint(paintAmount);//updates data
        paintBar.SetPaint(GameManager.gameManager.playerPaint.Paint);//updates UI
    }

    public void PlayerRegenPaint()
    {

        GameManager.gameManager.playerPaint.RegenPaint(currentRegenSpeed);//updates data
        paintBar.SetPaint(GameManager.gameManager.playerPaint.Paint);//updates UI
    }

} 