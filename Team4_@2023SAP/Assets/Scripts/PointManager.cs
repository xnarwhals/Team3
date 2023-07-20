using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : Singleton<PointManager>
{
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyDie>(UpdateScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(GameEvents.EnemyDie evt)
    {
        score += evt.score;
    }
}
