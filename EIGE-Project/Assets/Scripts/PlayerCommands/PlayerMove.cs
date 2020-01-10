using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerCommand
{
    public void run(PlayerManager player)
    {
        player.rigidbody2D.velocity = new Vector2(player.properties.movementSpeed * Input.GetAxis("Horizontal"), player.rigidbody2D.velocity.y);
    }
}
