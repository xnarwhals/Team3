using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Line Data")]
public class MarketDialogue : ScriptableObject
{
    public string[] lines;
    public int color1 = 0; //change to color scriptable obj maybe
    public int color2 = 0; //change to color scriptable obj maybe

    public float multiplier = 1.0f;
    public float difficulty = 1.0f;

    public Sprite CloseUp;
}
