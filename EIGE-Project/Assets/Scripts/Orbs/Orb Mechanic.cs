using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMechanic
{
    public OrbMechanic(OrbType type)
    {

    }

    public virtual void onPickup(PlayerManager player)
    {
        CameraShake.Shake(0.4f, 0.25f);
    }

    public virtual void holdingUpdate(PlayerManager player)
    {

    }

    public virtual void onDrop(PlayerManager player)
    {
        CameraShake.Shake(0.4f, 0.25f);
    }
}
