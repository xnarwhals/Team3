using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSprite : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();

    public float MiddleRange = 0.25f;

    UnityEngine.UI.Image img;

    int prevDirection;
    int Direction = 0;

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
            Direction = 1;
        else if (reticlePos < -MiddleRange)
            Direction = -1;
        else
            Direction = 0;

        if (Direction != prevDirection)
        {
            prevDirection = Direction;
            EvtSystem.EventDispatcher.Raise(new GameEvents.GunDirectionChange() { direction = Direction });

            img.sprite = Sprites[Direction + 1];
        }
    }
}
