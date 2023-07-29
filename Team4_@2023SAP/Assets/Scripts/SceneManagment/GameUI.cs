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
    }

    private void LoadGame()
    {
        Loader.Load(Loader.Scene.Level01);
    }


}
