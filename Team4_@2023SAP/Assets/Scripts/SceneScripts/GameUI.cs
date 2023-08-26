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

    public string newGameScene;
    public string gameCreditsScene;
    public string highScoresScene;
    public string skipScene;

    private void Awake()
    {
        newGame.onClick.AddListener(LoadGame);

        gameCredits.onClick.AddListener(LoadCredits);
        
        highScores.onClick.AddListener(LoadScores);

        skip.onClick.AddListener(SkipIntro);
    }

    private void LoadGame()
    {
        Loader.Load(newGameScene);
    }

    private void LoadCredits()
    {
        Loader.Load(gameCreditsScene);
    }

    private void LoadScores()
    {
        Loader.Load(highScoresScene);
    }

    private void SkipIntro()
    {
        Loader.Load(skipScene);
    }
}
