
public class DoubleJumpMechanic : OrbMechanic
{
    public override void onPickup(PlayerManager player)
    {
        player.GetComponent<PlayerManager>().getCommand<PlayerSingleJump>().enabled = false;
        player.GetComponent<PlayerManager>().getCommand<PlayerDoubleJump>().enabled = true;
    }

    public override void onDrop(PlayerManager player)
    {
        player.GetComponent<PlayerManager>().getCommand<PlayerDoubleJump>().enabled = false;
        player.GetComponent<PlayerManager>().getCommand<PlayerSingleJump>().enabled = true;
    }
}
