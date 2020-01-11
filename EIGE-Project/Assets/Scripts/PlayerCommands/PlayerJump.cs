using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerCommand
{
    public void run(PlayerManager player)
    {
        if (Input.GetButtonDown("Jump")) {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * player.properties.jumpVelocity;
        }
    }
}
