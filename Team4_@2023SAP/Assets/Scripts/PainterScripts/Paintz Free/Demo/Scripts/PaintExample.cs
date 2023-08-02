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
    [SerializeField] [Range(1f, 1.25f)] float regenMultiplier;
    bool isRegening = true;
    bool color = false;
    int[] colors = new int[2];



    //Refrence to the Bar + GameManager
    [SerializeField] PaintChangeUI paintBar;
    [SerializeField] private GameManager _gameManager;


    private Texture2D colorTex;

    private bool canPaint = true;
    public bool isDead;

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
        if (Input.GetKeyDown("x"))
        {
            color = !color;
            if (color)
            {
                brush.splatChannel = colors[0];
            }
            else
            {
                brush.splatChannel = colors[1];
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (canPaint && _gameManager.playerPaint.Paint > 0 && isRegening && !isDead)
            {
                paintRegenSpeed = 10f;
                PaintTarget.PaintCursor(brush);
                PlayerUsePaint(paintAmountUsed);
                if (IndexBrush) brush.splatIndex++;
            }
        }


        if (_gameManager.playerPaint.Paint <= 0)
        {
            isRegening = false;
            canPaint = false;
            paintRegenSpeed = paintRegenSpeed * regenMultiplier;

        }

        else if (_gameManager.playerPaint.Paint >= 100f)
        {
            isRegening = true;
            canPaint = true;

        }

        PlayerRegenPaint();

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
        _gameManager.playerPaint.UsePaint(paintAmount);//updates data
        paintBar.SetPaint(_gameManager.playerPaint.Paint);//updates UI
    }

    public void PlayerRegenPaint()
    {

        _gameManager.playerPaint.RegenPaint(paintRegenSpeed);//updates data
        paintBar.SetPaint(_gameManager.playerPaint.Paint);//updates UI

    }

} 