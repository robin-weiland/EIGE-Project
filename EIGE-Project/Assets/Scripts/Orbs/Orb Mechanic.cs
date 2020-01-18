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
            case OrbType.Light:
                return new LightMechanic();
            case OrbType.GravityRight:
                return new GravityMechanic(1);
            case OrbType.GravityUp:
                return new GravityMechanic(2);
            case OrbType.GravityLeft:
                return new GravityMechanic(3);
            case OrbType.Dash:
                return new DashMechanic(512);
            default:
                return new OrbMechanic();
        }
    }
}
