using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : OrbMechanic
{

    private ContactFilter2D contactFilter;
    private readonly Collider2D[] collider = new Collider2D[1];
    private int current = 0, cooldown = 20;
    private float dashSpeed = 13f;
    private bool disabled = false;
    private int dis = 0, disTime = 50;
    private bool slowdown = false;
    private float oldPlayerSpeed = 0;
    private GameObject arrowPrefab;
    private GameObject currentArrow;
    private GameObject dashField;
    private GameObject currentField;

    private float previousDrag;

    private List<PlayerCommand> interfering = new List<PlayerCommand>();
    
    public DashMechanic(LayerMask layer, GameObject arrow, GameObject dashField)
    {
        contactFilter = new ContactFilter2D
        {
            layerMask = layer,
            useLayerMask = true,
            useTriggers = true
        };
        this.dashField = dashField;
        this.arrowPrefab = arrow;
    }

    public override void onPickup(PlayerManager player)
    {
        interfering.Add(player.getCommand<PlayerMove>());
        interfering.Add(player.getCommand<PlayerMultiJump>());
        updateUI(player);
    }

    public override void holdingUpdate(PlayerManager player)
    {
        if (Input.GetButton("Action"))
        {
            int count = player.GetComponent<BoxCollider2D>().OverlapCollider(contactFilter, collider);
            if (count > 0)
            {
                if (!slowdown && current <= 0)
                {
                    foreach (PlayerCommand disable in interfering) disable.enabled = false;
                    slowdown = true;
                    if (currentArrow == null) currentArrow = Object.Instantiate(arrowPrefab);
                    if (currentField == null)
                    {
                        currentField = Object.Instantiate(dashField, player.transform.position, Quaternion.identity);
                        currentField.transform.parent = player.transform;
                    }
                    player.rigidbody2D.velocity /= 2;
                    Time.timeScale = 0.4f;
                    current = 10;
                }
                else current = 10;
            }
        }
        if (slowdown)
        {
            player.rigidbody2D.velocity *= 0.9f;
            if (currentArrow != null)
            {
                Color c = Color.white;
                c.a = Mathf.Min(current / 7f, 0.5f);
                currentArrow.GetComponent<SpriteRenderer>().color = c;
            }
            if (current > 0)
            {
                if (!Input.GetButton("Action"))
                {
                    foreach (PlayerCommand disable in interfering) disable.enabled = true;
                    slowdown = false;
                    Time.timeScale = 1f;
                    current = cooldown;
                    if (currentArrow != null) Object.Destroy(currentArrow);
                    currentArrow = null;
                }
            } else
            {
                foreach (PlayerCommand disable in interfering) disable.enabled = true;
                Time.timeScale = 1f;
                slowdown = false;
                collider[0] = null;
                if (currentArrow != null) Object.Destroy(currentArrow);
                //if (currentField != null) Object.Destroy(currentField);
                currentArrow = null;
            }
        }
        if (disabled && (dis < 0 || Physics2D.OverlapCircle(player.properties.feetPosition.position, player.properties.isGroundedCircleRadius, player.properties.isGround)))
        {
            foreach (PlayerCommand disable in interfering) disable.enabled = true;
            player.rigidbody2D.drag = previousDrag;
            disabled = false;
        } else dis--;
        if (current > 0) current--;
        if (currentArrow != null)
        {
            Vector2 direction = player.getDirection();
            currentArrow.transform.position = (Vector2)player.transform.position + direction;
            currentArrow.transform.localEulerAngles = new Vector3(0, 0, -Mathf.Atan2(direction.x / 2, direction.y / 2) * Mathf.Rad2Deg);
        }
        if (currentField != null && !(slowdown || disabled || collider[0] != null)) Object.Destroy(currentField);
        updateUI(player);
    }

    public override void holdingFixedUpdate(PlayerManager player)
    {
        if (collider[0] != null && !slowdown)
        {
            foreach (PlayerCommand disable in interfering) disable.enabled = false;

            Vector2 force = player.getDirection() * dashSpeed;
            player.rigidbody2D.velocity = force;
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

    private void updateUI(PlayerManager player)
    {
        if (player.orbUI != null)
        {
            if (collider[0] == null && dis <= 0)
            {
                player.orbUI.setUp(false);
            }
            else
            {
                player.orbUI.setUp(true);
            }
            player.orbUI.setFillStatus(dis / (float)disTime);
        }
    }
}
