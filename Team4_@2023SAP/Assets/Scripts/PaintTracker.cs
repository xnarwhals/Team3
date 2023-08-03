using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTracker : MonoBehaviour
{
    struct GridData
    {
        public GridData(BuildingGrid BuildingGrid, int tileX, int tileY)
        {
            buildingGrid = BuildingGrid;
            tiles = new int[tileX, tileY];
        }

        public BuildingGrid buildingGrid;
        public int[,] tiles;
    }

    List<GridData> grids = new List<GridData>();

    // Start is called before the first frame update
    void Awake()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.ShootPaint>(tileHit);

        EvtSystem.EventDispatcher.AddListener<GameEvents.RegisterBuildingGrid>(RegisterGrid);
    }

    void tileHit(GameEvents.ShootPaint evt)
    {
        for (int i = 0; i < grids.Count; i++)
        {
            if (grids[i].buildingGrid == evt.hitGrid)
            {
                grids[i].tiles[evt.hitCoords.x, evt.hitCoords.y]++;
                print(evt.hitCoords.x + ", " + evt.hitCoords.y + ": " + 
                    grids[i].tiles[evt.hitCoords.x, evt.hitCoords.y]);

                return;
            }
        }
    }

    void RegisterGrid(GameEvents.RegisterBuildingGrid evt)
    {
        BuildingGrid grid = evt.grid;
        grids.Add(new GridData(grid, grid.tiles.GetLength(0), grid.tiles.GetLength(1)));
    }
}
