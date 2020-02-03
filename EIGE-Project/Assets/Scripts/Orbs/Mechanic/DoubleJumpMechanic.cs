
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

    public override void holdingUpdate(PlayerManager player)
    {
        updateUI(player);
        
    }

    private void updateUI(PlayerManager player)
    {
        if (player.orbUI != null)
        {
            PlayerMultiJump jump = (PlayerMultiJump)player.getCommand<PlayerMultiJump>();
            if (jump.getCurrentJumps() >= 2)
            {
                player.orbUI.setFillStatus(0);
                player.orbUI.setUp(false);
            }
            else
            {
                player.orbUI.setFillStatus(1);
                player.orbUI.setUp(true);
            }
        }
    }
}
