using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager { get; private set; }

    public UnitPaint playerPaint = new UnitPaint(100f, 100f, 10f, false);


    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }


}
