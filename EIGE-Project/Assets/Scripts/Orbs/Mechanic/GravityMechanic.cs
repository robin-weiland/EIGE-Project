using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMechanic : OrbMechanic
{
    public override void onPickup(PlayerManager player)
    {
        player.rigidbody2D.SetRotation(90);
        Physics2D.gravity = new Vector2(9.8f, 0);
    }

    public override void onDrop(PlayerManager player)
    {
        player.rigidbody2D.SetRotation(-90);
        Physics2D.gravity = new Vector2(0, -9.8f);
    }
}
