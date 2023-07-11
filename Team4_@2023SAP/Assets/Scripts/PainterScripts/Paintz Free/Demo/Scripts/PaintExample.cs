﻿using UnityEngine;

public class PaintExample : MonoBehaviour
{
    public Brush brush;
    public bool RandomChannel = false;
    public bool SingleShotClick = false;
    public bool ClearOnClick = false;
    public bool IndexBrush = false;

    private Texture2D colorTex;

    private bool HoldingButtonDown = false;

    private void Start()
    {
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

        //if (RandomChannel) brush.splatChannel = Random.Range(0, 2);
         
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100.0f);

            if (!(hit.collider.gameObject.layer == LayerMask.NameToLayer("NonPaintable")))
            {
                if (!SingleShotClick || (SingleShotClick && !HoldingButtonDown))
                {
                    if (ClearOnClick) PaintTarget.ClearAllPaint();
                    PaintTarget.PaintCursor(brush);
                    if (IndexBrush) brush.splatIndex++;
                }
            }
            HoldingButtonDown = true;
        }
        else
        {
            HoldingButtonDown = false;
        }
    }
}