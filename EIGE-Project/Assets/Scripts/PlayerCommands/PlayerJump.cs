using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerDualCommand
{
    private float jumpTimeCounter;
    private bool grounded;
    private bool isJumping;

    public void run(PlayerManager player)
    {
        grounded = Physics2D.OverlapCircle(player.properties.feetPosition.position, player.properties.isGroundedCircleRadius, player.properties.isGround);

        if (grounded) {
            jumpTimeCounter = player.properties.maxJumpTime;
        }
    }

    public void fixedRun(PlayerManager player)
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                player.rigidbody2D.velocity = new Vector2(player.rigidbody2D.velocity.x, player.properties.jumpVelocity);
                isJumping = true;
            }
        }

        if (Input.GetButton("Jump") && isJumping) { 
            if(jumpTimeCounter > 0) {
                player.rigidbody2D.velocity = new Vector2(player.rigidbody2D.velocity.x, player.properties.jumpVelocity);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
            jumpTimeCounter = 0;
        }



    }
}
