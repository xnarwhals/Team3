using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public Vector2 TimeRange = new Vector2(8.0f, 12.0f);
    public Vector2Int EnemyCountRange = new Vector2Int(2, 4);

    float currentTime = 0.0f;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentTime)
        {
            timer = 0.0f;
            currentTime = Random.Range(TimeRange.x, TimeRange.y);

            int count = Random.Range(EnemyCountRange.x, EnemyCountRange.y);
            for (int i = 0; i < count; i++)
            {
                GameObject enemy = Instantiate(EnemyPrefab);

                EnemySpawn spawn = enemy.GetComponent<EnemySpawn>();
                spawn.spawnRow = Random.Range(0, GameGrid.Instance.height);
                spawn.startFromRight = Random.value > 0.5f;
            }
        }
    }
}
