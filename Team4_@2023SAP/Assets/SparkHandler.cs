using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SparkHandler : MonoBehaviour
{
    public GameObject prefab;

    GameObject current;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.ScanComplete>(Spark);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spark(GameEvents.ScanComplete evt) 
    {
        if (current == null)
        {
            current = Instantiate(prefab, transform);
        }
    }
}
