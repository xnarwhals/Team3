using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    [HideInInspector] public int activeScene;

    private void Awake()
    {
        ReturnActiveScene();
    }

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
        
    }

    public void ReturnActiveScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        activeScene = scene.buildIndex;
    }




}
