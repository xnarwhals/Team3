using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private void Awake()
    {
        Button newGame = GameObject.Find("New Game Btn").GetComponent<Button>();
        newGame.onClick.AddListener(LoadGame);

        Button gameCredits = GameObject.Find("End Credits Btn").GetComponent<Button>();
        gameCredits.onClick.AddListener(LoadCredits);

        Button highScores = GameObject.Find("High Scores Btn").GetComponent<Button>();
        highScores.onClick.AddListener(LoadScores);

        Button skip = GameObject.Find("Skip Intro Btn").GetComponent<Button>();
        skip.onClick.AddListener(SkipIntro);
    }

    private void LoadGame()
    {
        Loader.Load(Loader.Scene.MarketTest);
    }

    private void LoadCredits()
    {
        Loader.Load(Loader.Scene.ScrollingEndCredits);
    }

    private void LoadScores()
    {
        Loader.Load(Loader.Scene.HighScores);
    }

    private void SkipIntro()
    {
        Loader.Load(Loader.Scene.FinalizedBuild);
    }
}
