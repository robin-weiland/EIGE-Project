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

        //if (isJumping && grounded && jumpTimeCounter <= 0) isJumping = false;
        if (Input.GetButtonDown("Jump") && grounded) {
            player.rigidbody2D.velocity = player.transform.up * player.properties.jumpVelocity;
            isJumping = true;
            jumpTimeCounter = 50;
        }
        //if (jumpTimeCounter > 0) jumpTimeCounter--;
    }

    public override void fixedRun(PlayerManager player)
    {
        //if (!isJumping) return;
        Vector2 speedVector = player.rigidbody2D.velocity * (Vector2)player.transform.up;
        float speed = speedVector.x + speedVector.y;
        if (speed < 0)
        {
            player.rigidbody2D.velocity += ((Vector2)player.transform.up) * -Mathf.Abs(Physics2D.gravity.y + Physics2D.gravity.x) * player.properties.jumpDownMultiplier * Time.deltaTime;
        }
        else if (speed > 0 && !Input.GetButton("Jump"))
        {
            player.rigidbody2D.velocity += ((Vector2)player.transform.up) * -Mathf.Abs(Physics2D.gravity.y + Physics2D.gravity.x) * player.properties.jumpUpMultiplier * Time.deltaTime;
        }
    }
}
