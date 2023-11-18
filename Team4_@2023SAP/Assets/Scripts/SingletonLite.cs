using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonLite<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance = null;

    public static T Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = gameObject.GetComponent<T>();
        }
    }

    private void OnDestroy()
    {
        if (this == _instance)
        {
            _instance = null;
        }
    }
}
