
public abstract class PlayerCommand
{
    public bool enabled = true;

    public abstract void run(PlayerManager player);

}
