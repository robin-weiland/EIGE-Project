using UnityEngine;

public class PlayerMultiJump : PlayerDualCommand
{
    private bool _grounded;
    private int _jumpCounter;  // current jump determined by keystroke
    // property so it can be overriden
    public int AllowedJumps { get; protected set; }  // continuous jumps allowed by the script

    public PlayerMultiJump(int allowedJumps)
    {
        AllowedJumps = allowedJumps;
    }
    
    
    public override void run(PlayerManager player)
    {
        _grounded = Physics2D.OverlapCircle(player.properties.feetPosition.position,
            player.properties.isGroundedCircleRadius, player.properties.isGround);

        if (!Input.GetButtonDown("Jump")) return;
        if (_grounded) _jumpCounter = 0;
        if (_jumpCounter >= AllowedJumps) return;
        player.rigidbody2D.velocity = player.transform.up * player.properties.jumpVelocity;
        _jumpCounter++;
    }

    public override void fixedRun(PlayerManager player)
    {
        var speedVector = player.rigidbody2D.velocity * player.transform.up;
        var speed = speedVector.x + speedVector.y;
        if (speed < 0)
            player.rigidbody2D.velocity += (Vector2) player.transform.up
                                           * (-Mathf.Abs(Physics2D.gravity.y + Physics2D.gravity.x)
                                           * player.properties.jumpDownMultiplier * Time.deltaTime);
        else if (speed > 0 && !Input.GetButton("Jump"))
            player.rigidbody2D.velocity += (Vector2)player.transform.up
                                           * (-Mathf.Abs(Physics2D.gravity.y + Physics2D.gravity.x)
                                           * player.properties.jumpUpMultiplier * Time.deltaTime);
    }
}
