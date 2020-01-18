using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : OrbMechanic
{

    private ContactFilter2D contactFilter;
    private readonly Collider2D[] collider = new Collider2D[1];
    private int current = 0, cooldown = 50;
    private float dashSpeed = 10f;
    private bool disabled = false;
    private int dis = 0, disTime = 50;

    private float previousDrag;

    private List<PlayerCommand> interfering = new List<PlayerCommand>();
    
    public DashMechanic(LayerMask layer)
    {
        contactFilter = new ContactFilter2D
        {
            layerMask = layer,
            useLayerMask = true,
            useTriggers = true
        };
    }

    public override void onPickup(PlayerManager player)
    {
        interfering.Add(player.getCommand<PlayerMove>());
        interfering.Add(player.getCommand<PlayerJump>());
    }

    public override void holdingUpdate(PlayerManager player)
    {
        if (current <= 0 && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<BoxCollider2D>().OverlapCollider(contactFilter, collider);
            current = cooldown;
        }
        if (current > 0) current--;
        if (dis < 0 && disabled)
        {
            foreach (PlayerCommand disable in interfering) disable.enabled = true;
            player.rigidbody2D.drag = previousDrag;
            disabled = false;
        } else dis--;
    }

    public override void holdingFixedUpdate(PlayerManager player)
    {
        if (collider[0] != null)
        {
            foreach (PlayerCommand disable in interfering) disable.enabled = false;
            Vector2 force = new Vector2(dashSpeed, dashSpeed);
            player.rigidbody2D.velocity = force;
            //player.rigidbody2D.AddForce(force);
            Rigidbody2D other = collider[0].GetComponent<Rigidbody2D>();
            if (other != null) other.velocity = -force;
            collider[0] = null;
            previousDrag = player.rigidbody2D.drag;
            player.rigidbody2D.drag = 1f;
            dis = disTime;
            disabled = true;
        }
    }

    public override void onDrop(PlayerManager player)
    {
        interfering.Clear();
    }
}
