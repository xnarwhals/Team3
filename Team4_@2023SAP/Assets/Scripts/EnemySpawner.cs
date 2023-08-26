using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    
    public float StartDelay = 10.0f;
    public Vector2 TimeRange = new Vector2(8.0f, 12.0f);
    public Vector2Int EnemyCountRange = new Vector2Int(2, 4);
    public Vector2Int RowRange = new Vector2Int(0, 4);

    public int MaxEnemyCount = 5;

    float currentTime = 0.0f;
    float timer = 0.0f;

    float startTimer = 0.0f;

    List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyDie>(RemoveEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer < StartDelay)
        {
            startTimer += Time.deltaTime;
            return;
        }

        timer += Time.deltaTime;

        if (timer >= currentTime)
        {
            EvtSystem.EventDispatcher.Raise(new GameEvents.DroneWaveEnter());

            timer = 0.0f;
            currentTime = Random.Range(TimeRange.x, TimeRange.y);

            int count = Random.Range(EnemyCountRange.x, EnemyCountRange.y);
            if (count + enemies.Count >= MaxEnemyCount) 
                count = MaxEnemyCount - enemies.Count;

            SpawnEnemies(count);
        }
    }

    void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab);
            RegisterEnemy(enemy);

            EnemySpawn spawn = enemy.GetComponent<EnemySpawn>();
            spawn.spawnRow = Random.Range(RowRange.x, RowRange.y);
            spawn.startFromRight = Random.value > 0.5f;
        }
    }

    void RegisterEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    void RemoveEnemy(GameEvents.EnemyDie evt)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (evt.enemy == enemies[i])
            {
                enemies.Remove(enemies[i]);
            }
        }
    }
}
