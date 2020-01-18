using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : OrbMechanic
{

    private ContactFilter2D contactFilter;
    private readonly Collider2D[] collider = new Collider2D[1];
    private int current = 0, cooldown = 50;
    private float dashSpeed = 10f;
    
    public DashMechanic(LayerMask layer)
    {
        contactFilter = new ContactFilter2D
        {
            layerMask = layer,
            useLayerMask = true,
            useTriggers = true
        };
    }

    public override void holdingUpdate(PlayerManager player)
    {
        if (current <= 0 && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<BoxCollider2D>().OverlapCollider(contactFilter, collider);
            current = cooldown;
        }
        if (current > 0) current--;
    }

    public override void holdingFixedUpdate(PlayerManager player)
    {
        if (collider[0] != null)
        {
            Vector2 force = new Vector2(dashSpeed, dashSpeed);
            player.rigidbody2D.velocity = force;
            //player.rigidbody2D.AddForce(force);
            Rigidbody2D other = collider[0].GetComponent<Rigidbody2D>();
            if (other != null) other.velocity = -force;
            collider[0] = null;
        }
    }
}
