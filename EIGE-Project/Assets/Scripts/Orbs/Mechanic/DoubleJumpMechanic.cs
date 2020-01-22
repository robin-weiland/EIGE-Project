
public class DoubleJumpMechanic : OrbMechanic
{
    public override void onPickup(PlayerManager player)
    {
        ((PlayerMultiJump) player.getCommand<PlayerMultiJump>()).AllowedJumps = 2;
    }

    public override void onDrop(PlayerManager player)
    {
        ((PlayerMultiJump) player.getCommand<PlayerMultiJump>()).AllowedJumps = 1;
    }
}
