using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Button newGame;
    public Button gameCredits;
    public Button highScores;
    public Button skip;

    private void Awake()
    {
        newGame.onClick.AddListener(LoadGame);

        gameCredits.onClick.AddListener(LoadCredits);
        
        highScores.onClick.AddListener(LoadScores);

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
