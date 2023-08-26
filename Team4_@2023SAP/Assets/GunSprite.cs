using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSprite : MonoBehaviour
{
    public Sprite Left;
    public Sprite Middle;
    public Sprite Right;

    public float MiddleRange = 0.25f;

    UnityEngine.UI.Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float reticlePos = Reticle.Instance.transform.position.x;
        if (reticlePos > MiddleRange)
            img.sprite = Right;
        else if (reticlePos < -MiddleRange)
            img.sprite = Left;
        else
            img.sprite = Middle;
            
    }
}
