using UnityEngine;

public class ProjectileMechanic : OrbMechanic
{
    private GameObject projectile;

    private int current, cooldown = 50;

    public ProjectileMechanic(GameObject projectile)
    {
        this.projectile = projectile;
    }

    public override void holdingUpdate(PlayerManager player)
    {
        if (current <= 0 && (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.LeftShift)))
        {
            Vector2 direction = Input.mousePosition;
            direction = Camera.main.ScreenToWorldPoint(direction);
            direction = (direction - (Vector2)player.transform.position).normalized;
            Object.Instantiate(projectile, player.transform.position, Quaternion.Euler(0, 0, -Mathf.Atan2(direction.x / 2, direction.y / 2) * Mathf.Rad2Deg));
            current = cooldown;
        }
        else current--;
    }
}
