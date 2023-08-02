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

    GameObject playerGun;


    private void Awake()
    {
        gameManager = this;
        playerGun = GameObject.Find("projectileShooter");
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    public void GameOver()
    {
        enemySpawner.enabled = !enemySpawner.enabled;
        Cursor.visible = true;

        
        playerGun.SetActive(false);
        GameOverUI.SetActive(true);
    }

    public void Restart()
    {
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
}
