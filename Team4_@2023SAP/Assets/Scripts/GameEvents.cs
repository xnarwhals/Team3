using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public class StartDialogue : EvtSystem.Event
    {
        public MarketDialogue dialogueLine;
    }
}
