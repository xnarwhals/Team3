using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    public static LoadingManager Instance;

    public GameObject LoadingPanel;

    private string targetScene;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadingPanel.SetActive(false);
    }
    public void LoadScene(string number)
    {
        SceneManager.LoadScene(1);
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        LoadingPanel.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);

        while (!op.isDone)
            yield return null; // It continues running until it goes into the yield

        LoadingPanel.SetActive(false);
    }
}
