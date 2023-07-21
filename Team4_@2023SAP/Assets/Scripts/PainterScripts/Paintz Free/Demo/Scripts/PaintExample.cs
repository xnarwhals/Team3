using UnityEngine;

public class PaintExample : MonoBehaviour
{
    public Brush brush;
    public bool SingleShotClick = false;
    public bool IndexBrush = false;

    //Change Paint Variables 
    [SerializeField] [Range(1f, 45f)] float paintAmountUsed;
    [SerializeField] [Range(1f, 45f)] float paintRegenSpeed;
    [SerializeField] [Range(1f, 1.25f)] float regenMultiplier;
    bool isRegening = true;
    


    //Refrence to the Bar 
    [SerializeField] PaintChangeUI paintBar;

    private Texture2D colorTex;

    private bool canPaint = true;

    private void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.NoPaintMouseOver>(UpdateNoPaint);

        colorTex = new Texture2D(1, 1);

        if (brush.splatTexture == null)
        {
            brush.splatTexture = Resources.Load<Texture2D>("splats");
            brush.splatsX = 4;
            brush.splatsY = 4;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) brush.splatChannel = 0;//orange
        if (Input.GetKeyDown(KeyCode.Alpha2)) brush.splatChannel = 1;//red
        if (Input.GetKeyDown(KeyCode.Alpha3)) brush.splatChannel = 2;//blue
        if (Input.GetKeyDown(KeyCode.Alpha4)) brush.splatChannel = 3;//green


        if (Input.GetMouseButtonDown(0))
        {
            if(canPaint && GameManager.gameManager.playerPaint.Paint > 0 && isRegening)
            {
                paintRegenSpeed = 10f;
                PaintTarget.PaintCursor(brush);
                PlayerUsePaint(paintAmountUsed);
                if (IndexBrush) brush.splatIndex++;
            }         
        }


        if (GameManager.gameManager.playerPaint.Paint <= 0)
        {
            isRegening = false;
            canPaint = false;
            paintRegenSpeed = paintRegenSpeed * regenMultiplier;
          
        }

        else if (GameManager.gameManager.playerPaint.Paint >= 100f)
        {
            isRegening = true;
            canPaint = true;

        }

        PlayerRegenPaint();





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

        GameManager.gameManager.playerPaint.RegenPaint(paintRegenSpeed);//updates data
        paintBar.SetPaint(GameManager.gameManager.playerPaint.Paint);//updates UI

    }

} 