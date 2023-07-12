using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPaint : MonoBehaviour
{
    private void OnMouseOver()
    {
        EvtSystem.EventDispatcher.Raise(new GameEvents.NoPaintMouseOver { isOver = true });
    }

    private void OnMouseExit()
    {
        EvtSystem.EventDispatcher.Raise(new GameEvents.NoPaintMouseOver { isOver = false });
    }
}
