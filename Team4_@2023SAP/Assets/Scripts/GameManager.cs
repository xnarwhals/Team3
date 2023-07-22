using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{

    public static GameManager gameManager { get; private set; }

    public UnitPaint playerPaint = new UnitPaint(100f, 100f, 10f, false);

    public UnitIdentity playerIdentity = new UnitIdentity(0, 100);

    [SerializeField] private SceneLoadingManager _sceneLoadingManager;

    [SerializeField] private bool _isGameOver;

    [SerializeField] private GameObject GameOverUI;


    void Start()
    {
        _isGameOver = false;
        FetchComponents();
    }

    void FetchComponents()
    {
        _sceneLoadingManager = GameObject.Find("SceneLoadingManager").GetComponent<SceneLoadingManager>();

        if (_sceneLoadingManager == null)
        {
            Debug.Log("THERE IS NO SCENE LOADING MANAGER IN SCENE :)");
        }
    }

    public void Restart()
    {
        if (_isGameOver == true)
        {
            int sceneID = _sceneLoadingManager.activeScene;
            _sceneLoadingManager.LoadLevel(sceneID);
        }
        else if(_isGameOver == false)
        {
            Debug.Log("No, Play The Game");
        }
    }

    public void SetGameOver()
    {
        GameOverUI.SetActive(true);
        _isGameOver = true;
        
    }

    public void QuitGame()
    {

    }

}
