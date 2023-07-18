using UnityEngine;

public class PaintExample : MonoBehaviour
{
    public Brush brush;
    public bool SingleShotClick = false;
    public bool IndexBrush = false;
     
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
        if (Input.GetKeyDown(KeyCode.Alpha5)) brush.splatChannel = 4; //Paint Removal Functionality 

         
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.LeftShift))
        {
            if (canPaint)
            {
                {                
                    PaintTarget.PaintCursor(brush);
                    PlayerUsePaint(10f);
                    if (IndexBrush) brush.splatIndex++;
                }
            }
        
        }
        else
        {
     
            PlayerRegenPaint();
   
        }
    }

    void UpdateNoPaint(GameEvents.NoPaintMouseOver evt)
    {
        canPaint = !evt.isOver;
    }

    private void PlayerUsePaint(float paintAmount)
    {
        GameManager.gameManager.playerPaint.UsePaint(paintAmount);//updates data
        paintBar.SetPaint(GameManager.gameManager.playerPaint.Paint);//updates UI
    }

    private void PlayerRegenPaint()
    {
        GameManager.gameManager.playerPaint.RegenPaint();//updates data
        paintBar.SetPaint(GameManager.gameManager.playerPaint.Paint);//updates UI
    }
} 