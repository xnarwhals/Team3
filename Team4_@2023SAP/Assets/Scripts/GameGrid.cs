using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class GameGrid : MonoBehaviour
{
    #region singleton
    public static GameGrid Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        UpdateGrid();
    }
    #endregion singleton


    public int width = 9;
    public int height = 16;
    public float cellSize = 2.0f;

    public GameObject gridPrefab;

    public Vector2[,] tiles;

    Vector2 cellShape;


    private void Update()
    {
        UpdateGrid();
    }

    private void UpdateGrid()
    {
        cellShape = new Vector2(1.6f * cellSize, 0.85f * cellSize) * (Camera.main.orthographicSize / 5);

        tiles = new Vector2[width, height];
        transform.position = new Vector2(-(width * 0.5f * cellShape.x - 0.5f * cellShape.x),
            height * 0.5f * cellShape.y - 0.5f * cellShape.y);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 newCell = new Vector2(transform.position.x + i * cellShape.x, 
                    transform.position.y - j * cellShape.y);

                tiles[i, j] = newCell;

                drawDebugCell(newCell);
            }
        }
    }

    private void drawDebugCell(Vector2 cell)
    {
        //x for center of cell
        Debug.DrawLine(new Vector2(cell.x - 0.1f, cell.y - 0.1f),
                    new Vector2(cell.x + 0.1f, cell.y + 0.1f));
        Debug.DrawLine(new Vector2(cell.x + 0.1f, cell.y - 0.1f),
            new Vector2(cell.x - 0.1f, cell.y + 0.1f));

        /*Debug.DrawLine(new Vector2(cell.x - cellShape.x / 2, cell.y + cellShape.y / 2),
            new Vector2(cell.x + cellShape.x / 2, cell.y + cellShape.y / 2));
        Debug.DrawLine(new Vector2(cell.x + cellShape.x / 2, cell.y + cellShape.y / 2),
            new Vector2(cell.x + cellShape.x / 2, cell.y - cellShape.y / 2));
        Debug.DrawLine(new Vector2(cell.x + cellShape.x / 2, cell.y - cellShape.y / 2),
            new Vector2(cell.x - cellShape.x / 2, cell.y - cellShape.y / 2));
        Debug.DrawLine(new Vector2(cell.x - cellShape.x / 2, cell.y - cellShape.y / 2),
            new Vector2(cell.x - cellShape.x / 2, cell.y + cellShape.y / 2));*/
    }
}
