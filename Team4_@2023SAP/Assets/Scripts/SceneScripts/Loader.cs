using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader
{

    public enum Scene
    {
        TitleScreen,
        Loading,
        Load,
        ScrollingEndCredits,
        HighScores,
        MarketTest,
        FinalizedBuild,
        HowToPlay

    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void Load(string scene)
    {
        GameObject sceneHolderObj = new GameObject("SceneHolder");
        SceneHolder sceneHolder = sceneHolderObj.AddComponent<SceneHolder>();
        sceneHolder.SceneName = scene;

        SceneManager.LoadScene(Scene.Load.ToString());
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
