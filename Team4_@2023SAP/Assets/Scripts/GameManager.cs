using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{ 
    public static GameManager gameManager { get; private set; }

    public UnitPaint playerPaint = new UnitPaint(100f, 100f, 10f, false);

    public UnitIdentity playerIdentity = new UnitIdentity(0, 100);

    public GameObject gameOverUI;

    GameObject playerGun;

    public bool _isGameOver = false;


    private void Awake()
    {
        gameManager = this;
        playerGun = GameObject.Find("projectileShooter");
    }

    

    public void GameOver()
    {
        _isGameOver = true;
        playerGun.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        _isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerIdentity.Identity = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Quit()
    {
        Application.Quit(); 
    }



}
