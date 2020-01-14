using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMechanic : OrbMechanic
{
    private Light light;
    public override void onDrop(PlayerManager player)
    {
        light = player.GetComponentInChildren<Light>(true);
        light.enabled = false;
    }

    public override void onPickup(PlayerManager player)
    {
        light = player.GetComponentInChildren<Light>(false);
        light.enabled = true;
    }

    public override void holdingUpdate(PlayerManager player)
    {
        // When you need to update something
    }

    public override void holdingFixedUpdate(PlayerManager player)
    {
        // When you need to fixed update something
    }
}
