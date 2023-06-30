using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public Texture2D cursorTexture;//Texture   
    public CursorMode cursorMode = CursorMode.Auto;//Size makes image fit cursor 
    public Vector2 hotSpot = Vector2.zero;//Click and interact with things  

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }






}
