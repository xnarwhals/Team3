using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildingGrid : MonoBehaviour
{
    public Vector2[,] tiles;
    public Vector2 tileSize;

    public int width;
    public int height;

    public bool showLines;
    public bool showXs;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGrid();

        EvtSystem.EventDispatcher.Raise(new GameEvents.RegisterBuildingGrid { grid = this });
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGrid();
    }

    private void UpdateGrid()
    {
        tiles = new Vector2[width, height];
        Vector2 origin = (Vector2)transform.position + new Vector2(-(width * 0.5f * tileSize.x - 0.5f * tileSize.x),
            height * 0.5f * tileSize.y - 0.5f * tileSize.y);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 newCell = new Vector2(origin.x + i * tileSize.x,
                    origin.y - j * tileSize.y);

                tiles[i, j] = newCell;

                drawDebugCell(newCell);
            }
        }
    }

    private void drawDebugCell(Vector2 cell)
    {
        if (showXs)
        {
            //x for center of cell
            Debug.DrawLine(new Vector2(cell.x - 0.1f, cell.y - 0.1f),
                        new Vector2(cell.x + 0.1f, cell.y + 0.1f));
            Debug.DrawLine(new Vector2(cell.x + 0.1f, cell.y - 0.1f),
                new Vector2(cell.x - 0.1f, cell.y + 0.1f));
        }

        if (showLines)
        {
            Debug.DrawLine(new Vector2(cell.x - tileSize.x / 2, cell.y + tileSize.y / 2),
            new Vector2(cell.x + tileSize.x / 2, cell.y + tileSize.y / 2));
            Debug.DrawLine(new Vector2(cell.x + tileSize.x / 2, cell.y + tileSize.y / 2),
                new Vector2(cell.x + tileSize.x / 2, cell.y - tileSize.y / 2));
            Debug.DrawLine(new Vector2(cell.x + tileSize.x / 2, cell.y - tileSize.y / 2),
                new Vector2(cell.x - tileSize.x / 2, cell.y - tileSize.y / 2));
            Debug.DrawLine(new Vector2(cell.x - tileSize.x / 2, cell.y - tileSize.y / 2),
                new Vector2(cell.x - tileSize.x / 2, cell.y + tileSize.y / 2));
        }
    }
}
