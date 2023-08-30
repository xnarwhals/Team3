using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour

/*public GameObject LoadingPanel; // Public Slider? Somewhere in the code insert "LoadingPanel.value = asyncLoad.progress"
public float MinLoadTime;*/

{
    void Start()
    {
        SceneManager.LoadSceneAsync(SceneHolder.Instance.SceneName);
        Destroy(SceneHolder.Instance);
    }

    void Update()
    {
        
    }
}
