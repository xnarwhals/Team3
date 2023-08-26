using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(SceneHolder.Instance.SceneName);
        Destroy(SceneHolder.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
