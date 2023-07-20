using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int spawnRow = 0;
    public bool startFromRight = false;

    public Vector2 spawnOffset = new Vector2(1.0f, 1.0f);

    GameGrid grid;

    private void Start()
    {
        grid = GameGrid.Instance;

        Vector2 pos = grid.tiles[startFromRight ? grid.tiles.GetLength(0) - 1 : 0, spawnRow];

        Vector2 tPos = pos; //for target
        if (tPos == grid.tiles[0, 0]) tPos = grid.tiles[1, 0];
        else if (tPos == grid.tiles[grid.tiles.GetLength(0) - 1, 0]) 
            tPos = grid.tiles[grid.tiles.GetLength(0) - 2, 0];
        GetComponent<DroneMovement>().target = tPos;

        pos += new Vector2(startFromRight ? spawnOffset.x : -spawnOffset.x, spawnOffset.y);

        transform.position = pos;
    }
}
