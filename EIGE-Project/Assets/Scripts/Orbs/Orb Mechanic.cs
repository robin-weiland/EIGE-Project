using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMechanic
{
    public OrbMechanic()
    {
    }

    public virtual void onPickup(PlayerManager player)
    {
    }

    public virtual void holdingFixedUpdate(PlayerManager player)
    {

    }

    public virtual void holdingUpdate(PlayerManager player)
    {

    }

    public virtual void onDrop(PlayerManager player)
    {
    }

    public static OrbMechanic GetOrbMechanic(OrbType type)
    {
        switch (type)
        {
            case OrbType.Test:
                return new TestMechanic();
        }
        return new OrbMechanic();
    }
}
