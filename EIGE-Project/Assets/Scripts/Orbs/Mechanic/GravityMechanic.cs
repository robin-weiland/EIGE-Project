using UnityEngine;

public class GravityMechanic : OrbMechanic
{
    private float rotation = 0;
    private Vector2 direction;
    private bool enabled = false;
    private int current = 0, cooldown = 100;
    private ParticleSystem particles;

    // Type of Gravitation: 1: Right 2: Up 3: Left 
    public GravityMechanic(int type, ParticleSystem particles = null)
    {
        if (type == 1) rotation = 90;
        if (type == 2) rotation = 180;
        if (type == 3) rotation = -90;
        direction = new Vector2(-(type - 2) * 9.8f, type == 2 ? 9.8f : 0f);
        this.particles = particles;
    }

    public override void onPickup(PlayerManager player)
    {
        current = 0;
        updateUI(player);
    }

    public override void holdingUpdate(PlayerManager player)
    {
        if (current <= 0 && Input.GetButton("Action"))
        {
            if (enabled) disable(player);
            else enable(player);
            current = cooldown;
        }
        if (current > 0)
        {
            current--;
            updateUI(player);
        }
    }

    public override void onDrop(PlayerManager player)
    {
        disable(player);
    }

    private void enable(PlayerManager player)
    {
        if (enabled) return;
        player.rigidbody2D.rotation = rotation;
        player.rigidbody2D.velocity = new Vector2(0, 0);
        Physics2D.gravity = direction;
        enabled = true;
        if (particles != null) particles.Play();
        updateUI(player);
    }

    private void disable(PlayerManager player) {
        if (!enabled) return;
        player.rigidbody2D.SetRotation(0);
        player.rigidbody2D.velocity = new Vector2(0, 0);
        Physics2D.gravity = new Vector2(0, -9.8f);
        enabled = false;
        if (particles != null) particles.Play();
        updateUI(player);
    }

    private void updateUI(PlayerManager player)
    {
        if (player.orbUI != null)
        {
            if (current > 0)
            {
                player.orbUI.setFillStatus((cooldown - current) / (float)cooldown);
                player.orbUI.setUp(false);
            } else
            {
                player.orbUI.setFull();
                player.orbUI.setUp(true);
            }
        }
    }
}
