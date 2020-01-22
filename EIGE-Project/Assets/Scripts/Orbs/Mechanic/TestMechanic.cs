using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMechanic : OrbMechanic
{
    // Don't forget to add a enum to OrbType and your mechanic in the switch of orb mechanic
    public override void onDrop(PlayerManager player)
    {
        // Just an excample
        player.getCommand<PlayerSingleJump>().enabled = true;
    }

    public override void onPickup(PlayerManager player)
    {
        player.getCommand<PlayerSingleJump>().enabled = false;
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
