using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsEnd : MonoBehaviour
{
    public string NextScene = "TitleScreen";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        foreach (PaintTarget wall in FindObjectsByType<PaintTarget>(sortMode: FindObjectsSortMode.None))
        {
            Destroy(wall.gameObject);
        }
        Loader.Load(NextScene);
    }
}
