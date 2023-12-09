using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonLite<GameManager>
{ 
    public static GameManager gameManager { get; private set; }

    public UnitPaint playerPaint = new UnitPaint(100f, 100f, 10f, false);

    public UnitIdentity playerIdentity = new UnitIdentity(0, 100);

    private EnemySpawner enemySpawner;

    [SerializeField] private GameObject GameOverUI;

    GameObject[] playerInputs;


    private void Start()
    {
        gameManager = this;
        playerInputs = new GameObject[] { FindAnyObjectByType<PaintShooter>().gameObject,
            FindAnyObjectByType<ProjectileShooter>().gameObject};

        enemySpawner = FindAnyObjectByType<EnemySpawner>();

        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyDie>(RestoreIdentity);

        playerIdentity.identityScript = FindAnyObjectByType<IdentityChangeUI>();//this is not good
    }

    public void GameOver()
    {
        EvtSystem.EventDispatcher.Raise(new GameEvents.GameOver());

        enemySpawner.enabled = !enemySpawner.enabled;
        Cursor.visible = true;


        playerInputs[0].SetActive(false);
        playerInputs[1].SetActive(false);
        GameOverUI.SetActive(true);
    }

    public void Restart()
    {
        //playerInputs[0].SetActive(true);
        //playerInputs[1].SetActive(true);
        
        Cursor.visible = false;
        playerIdentity.Identity = 0f;
        playerPaint.Paint = 100f;
        Time.timeScale = 1.0f;

        foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))
        {
            //Destroy(obj);
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //Destroy(gameObject);
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
