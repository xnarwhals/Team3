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

    public class ContinueDialogue : EvtSystem.Event
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

    public class DroneWaveEnter : EvtSystem.Event 
    {
        //public GameObject drone;
    }


    public class NoPaintMouseOver : EvtSystem.Event
    {
        public bool isOver;
    }

    public class ShootProjectile : EvtSystem.Event 
    {

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
        public float identityRestore;
    }

    public class ScanStart : EvtSystem.Event
    {
        public GameObject enemy;
    }

    public class ScanComplete : EvtSystem.Event
    {

    }

    public class UpdateScore : EvtSystem.Event
    {
        public int score;
    }

    public class ShootPaint : EvtSystem.Event
    {
        public Vector2 position;
        public BuildingGrid hitGrid;
        public Vector2Int hitCoords;
    }

    public class RegisterBuildingGrid : EvtSystem.Event
    {
        public BuildingGrid grid;
    }

    public class ColorWheelChange : EvtSystem.Event
    {
        public string color; //not in use rn
    }
}
