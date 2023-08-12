using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temphow2playbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void press()
    {
        Loader.Load(Loader.Scene.FinalizedBuild);
    }
}
