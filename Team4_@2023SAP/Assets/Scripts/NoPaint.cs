using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPaint : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Building")
            || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            EvtSystem.EventDispatcher.Raise(new GameEvents.NoPaintMouseOver 
                { isOver = true });
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Building") 
            || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            EvtSystem.EventDispatcher.Raise(new GameEvents.NoPaintMouseOver 
                { isOver = false });
    }
}
