using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitIdentity
{
    public int curIdentity;
    public int maxIdentity;

    public int Identity
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

    public int MaxIdentity 
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

    public UnitIdentity(int Identity, int maximumIdentity)
    {
        curIdentity = Identity;
        maxIdentity = maximumIdentity;
    }

    public void IdentityLose(int identityLost)
    {
        if (curIdentity < maxIdentity)
        {
            curIdentity += identityLost;
        }

    }

}
