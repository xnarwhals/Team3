using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
    public float intensity = 1.0f;
    public float roughness = 1.0f;
    public float fadeInTime = 0.2f;
    public float fadeOutTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.ScanComplete>(Scan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Scan(GameEvents.ScanComplete evt)
    {
        EZCameraShake.CameraShaker.Instance.ShakeOnce
            (intensity, roughness, fadeInTime, fadeOutTime);
    }
}
