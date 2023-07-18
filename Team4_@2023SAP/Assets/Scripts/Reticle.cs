using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public Texture2D[] cursorTexture;//Texture   
    public CursorMode cursorMode = CursorMode.Auto;//Size makes image fit cursor 
    public Vector2 hotSpot = Vector2.zero;//Click and interact with things  

    public void Start()
    {
        Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
    }

    /*public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    } */

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1))) Cursor.SetCursor(cursorTexture[1], hotSpot, cursorMode);
        if ((Input.GetKeyDown(KeyCode.Alpha2))) Cursor.SetCursor(cursorTexture[2], hotSpot, cursorMode);
        if ((Input.GetKeyDown(KeyCode.Alpha3))) Cursor.SetCursor(cursorTexture[3], hotSpot, cursorMode);
        if ((Input.GetKeyDown(KeyCode.Alpha4))) Cursor.SetCursor(cursorTexture[4], hotSpot, cursorMode);
        if ((Input.GetKeyDown(KeyCode.Alpha5))) Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
    }

    private void OnMouseOver()
    {
        
    }





}
