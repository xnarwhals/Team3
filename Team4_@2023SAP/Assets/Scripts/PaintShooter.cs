using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaintShooter : MonoBehaviour
{
    public float fireRate = 0.1f;
    public float shotRadius = 0.05f;

    bool[,] tilesPainted;

    float fireTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton0)) 
            && fireTimer >= fireRate)
        {
            fireTimer = 0;

            BuildingGrid grid = GetHitBuilding();
            if (grid == null) return;

            Vector2 pos = GetHitTile(grid);

            EvtSystem.EventDispatcher.Raise(new GameEvents.ShootPaint() { position = pos });
        }
    }

    BuildingGrid GetHitBuilding()
    {
        Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(Reticle.Instance.transform.position));

        RaycastHit[] hits = Physics.RaycastAll(ray);
        for (int h = 0; h < hits.Length; h++)
        {
            BuildingGrid grid = hits[h].collider.gameObject.GetComponent<BuildingGrid>();
            if (grid != null)
            {
                return grid;
            }
        }

        return null; //never happens
    }

    Vector2 GetHitTile(BuildingGrid grid)
    {
        Vector2[,] tiles = grid.tiles;

        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Vector2 pos = Reticle.Instance.transform.position;
                Vector2 tile = tiles[i, j];

                if (pos.x >= tile.x - (grid.tileSize.x * 0.5f) && pos.x <= tile.x + (grid.tileSize.x * 0.5f)
                    && pos.y >= tile.y - (grid.tileSize.x * 0.5f) && pos.y <= tile.y + (grid.tileSize.y * 0.5f))
                {
                    return tile;
                }
            }
        }

        return new Vector2(1000.0f, 1000.0f);
    }
}
