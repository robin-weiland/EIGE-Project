using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMechanic : OrbMechanic
{
    private float rotation = 0;
    private Vector2 direction;

    // Type of Gravitation: 1: Right 2: Up 3: Left 
    public GravityMechanic(int type)
    {
        if (type == 1) rotation = 90;
        if (type == 2) rotation = 180;
        if (type == 3) rotation = -90;
        direction = new Vector2(-(type - 2) * 9.8f, type == 2 ? 9.8f : 0f);
    }

    public override void onPickup(PlayerManager player)
    {
        player.rigidbody2D.rotation = rotation;
        player.rigidbody2D.velocity = new Vector2(0, 0);
        Physics2D.gravity = direction;
    }

    public override void onDrop(PlayerManager player)
    {
        player.rigidbody2D.SetRotation(0);
        player.rigidbody2D.velocity = new Vector2(0, 0);
        Physics2D.gravity = new Vector2(0, -9.8f);
    }
}
