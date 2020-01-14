using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMechanic : OrbMechanic
{
    public override void onDrop(PlayerManager player)
    {
        player.GetComponentInChildren<Light>().enabled = false;
    }

    public override void onPickup(PlayerManager player)
    {
        player.GetComponentInChildren<Light>().enabled = true;
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
