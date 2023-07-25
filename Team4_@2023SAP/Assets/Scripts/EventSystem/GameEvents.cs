using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public class StartDialogue : EvtSystem.Event
    {
        public MarketDialogue dialogueLine;
        public int index;
    }

    public class EndDialogue : EvtSystem.Event
    {

    }

    public class DroneSwitchStart : EvtSystem.Event 
    {
        public GameObject drone;
    }

    public class DroneSwitchDone : EvtSystem.Event
    {
        public GameObject drone;
    }

    public class NoPaintMouseOver : EvtSystem.Event
    {
        public bool isOver;
    }

    public class ShootProjectile : EvtSystem.Event 
    {

    }

    public class SendReticlePos : EvtSystem.Event
    {
        public Vector2 reticlePos;
    }

    public class GameOver : EvtSystem.Event //for future? 
    {

    }

    public class EnemyHit : EvtSystem.Event
    {
        public GameObject enemy;
    }

    public class EnemyDie : EvtSystem.Event
    {
        public GameObject enemy;
        public int score;
    }
}
