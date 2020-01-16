using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerDualCommand
{
    private float jumpTimeCounter;
    private bool grounded;
    private bool isJumping;

    public override void run(PlayerManager player)
    {
        grounded = Physics2D.OverlapCircle(player.properties.feetPosition.position, player.properties.isGroundedCircleRadius, player.properties.isGround);

        if (Input.GetButtonDown("Jump") && grounded) {
            player.rigidbody2D.velocity = player.transform.up * player.properties.jumpVelocity;
        }
    }

    public override void fixedRun(PlayerManager player)
    {
        if (player.rigidbody2D.velocity.y < 0)
        {
            player.rigidbody2D.velocity += ((Vector2)player.transform.up) * Physics2D.gravity.y * player.properties.jumpDownMultiplier * Time.deltaTime;
        }
        else if (player.rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            player.rigidbody2D.velocity += ((Vector2)player.transform.up) * Physics2D.gravity.y * player.properties.jumpUpMultiplier * Time.deltaTime;
        }
    }
}
