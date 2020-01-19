using System.Collections;
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
    private GameObject arrowPrefab;
    private GameObject currentArrow;

    private float previousDrag;

    private List<PlayerCommand> interfering = new List<PlayerCommand>();
    
    public DashMechanic(LayerMask layer, GameObject arrow)
    {
        contactFilter = new ContactFilter2D
        {
            layerMask = layer,
            useLayerMask = true,
            useTriggers = true
        };
        this.arrowPrefab = arrow;
    }

    public override void onPickup(PlayerManager player)
    {
        interfering.Add(player.getCommand<PlayerMove>());
        interfering.Add(player.getCommand<PlayerJump>());
    }

    public override void holdingUpdate(PlayerManager player)
    {
        if (current <= 0 && (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.LeftShift)))
        {
            int count = player.GetComponent<BoxCollider2D>().OverlapCollider(contactFilter, collider);
            if (count > 0)
            {
                slowdown = true;
                if (currentArrow == null) currentArrow = Object.Instantiate(arrowPrefab);
                player.rigidbody2D.velocity /= 2;
                Time.timeScale = 0.5f;
                current = 10;
            }
        }
        if (slowdown)
        {
            if (current > 0)
            {
                if (!(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.LeftShift)))
                {
                    slowdown = false;
                    Time.timeScale = 1f;
                    current = cooldown;
                    if (currentArrow != null) Object.Destroy(currentArrow);
                    currentArrow = null;
                }
            } else
            {
                Time.timeScale = 1f;
                slowdown = false;
                collider[0] = null;
                if (currentArrow != null) Object.Destroy(currentArrow);
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
            Vector2 direction = Input.mousePosition;
            direction = Camera.main.ScreenToWorldPoint(direction);
            direction = (direction - (Vector2)player.transform.position).normalized;
            currentArrow.transform.position = (Vector2)player.transform.position + direction;
            currentArrow.transform.localEulerAngles = new Vector3(0, 0, -Mathf.Atan2(direction.x / 2, direction.y / 2) * Mathf.Rad2Deg);
        }
    }

    public override void holdingFixedUpdate(PlayerManager player)
    {
        if (collider[0] != null && !slowdown)
        {
            foreach (PlayerCommand disable in interfering) disable.enabled = false;

            Vector2 direction = Input.mousePosition;
            direction = Camera.main.ScreenToWorldPoint(direction);
            Vector2 force = (direction - (Vector2)player.transform.position).normalized * dashSpeed;
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
