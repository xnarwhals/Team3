using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.UpdateScore>(UpdateScore);

        text = GetComponent<TextMeshProUGUI>();
    }

    void UpdateScore(GameEvents.UpdateScore evt)
    {
        text.text = ("Score : " + PointManager.Instance.score);
    }
}
