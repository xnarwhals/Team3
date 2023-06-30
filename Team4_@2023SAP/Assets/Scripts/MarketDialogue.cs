using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Line Data")]
public class MarketDialogue : ScriptableObject
{
    public string text;
    public string color; //change to color scriptable obj maybe

    public float multiplier = 1.0f;
    public float difficulty = 1.0f;
}
