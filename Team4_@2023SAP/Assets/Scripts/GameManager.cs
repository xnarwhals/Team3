using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{ 
    public static GameManager gameManager { get; private set; }

    public UnitPaint playerPaint = new UnitPaint(100f, 100f, 10f, false);

    public UnitIdentity playerIdentity = new UnitIdentity(0, 100);

    private EnemySpawner enemySpawner;

    [SerializeField] private GameObject GameOverUI;

    GameObject playerInputs;


    private void Awake()
    {
        gameManager = this;
        playerInputs = GameObject.Find("PlayerInputs");
        enemySpawner = GameObject.Find("EnemyHandler").GetComponent<EnemySpawner>();

        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyDie>(RestoreIdentity);

        playerIdentity.identityScript = FindAnyObjectByType<IdentityChangeUI>();//this is not good
    }

    public void GameOver()
    {
        enemySpawner.enabled = !enemySpawner.enabled;
        Cursor.visible = true;

        
        playerInputs.SetActive(false);
        GameOverUI.SetActive(true);
    }

    public void Restart()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerIdentity.Identity = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void RestoreIdentity(GameEvents.EnemyDie evt)
    {
        playerIdentity.IdentityLose(-evt.identityRestore);
    }
}
