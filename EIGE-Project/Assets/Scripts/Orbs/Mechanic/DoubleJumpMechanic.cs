
public class DoubleJumpMechanic : OrbMechanic
{
    public override void onPickup(PlayerManager player)
    {
        player.GetComponent<PlayerManager>().GetComponent<PlayerMultiJump>().AllowedJumps = 2;
    }

    public override void onDrop(PlayerManager player)
    {
        player.GetComponent<PlayerManager>().GetComponent<PlayerMultiJump>().AllowedJumps = 1;
    }
}
