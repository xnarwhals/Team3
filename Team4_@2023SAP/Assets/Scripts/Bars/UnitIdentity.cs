using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitIdentity
{
    public float curIdentity;
    public float maxIdentity;

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
        if (curIdentity < maxIdentity)
        {
            curIdentity += identityLost; 
        }

    }

}
