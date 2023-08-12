using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitIdentity
{
    public float curIdentity;
    public float maxIdentity;

    [DoNotSerialize]
    public IdentityChangeUI identityScript;

    public float Identity
    {
        get
        {
            return curIdentity;
        }
        set
        {
            curIdentity = value;
        }
    }

    public float MaxIdentity 
    {
        get
        {
            return maxIdentity;
        }
        set
        {
            maxIdentity = value;
        }
    }

    public UnitIdentity(float Identity, float maximumIdentity)
    {
        curIdentity = Identity;
        maxIdentity = maximumIdentity;
    }

    public void IdentityLose(float identityLost)
    {
        if (curIdentity < maxIdentity && curIdentity + identityLost >= 0)
        {
            curIdentity += identityLost;
            identityScript.SetIdentity(Identity);
        }
    }
}
