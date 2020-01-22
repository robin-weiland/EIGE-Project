
public class LightMechanic : OrbMechanic
{
    private int child_index = 1;  // probably has to stay one
    public override void onDrop(PlayerManager player)
    {
        // Watch out if we change/add children we might have to change the index here as well, same in the method below
        player.transform.GetChild(child_index).gameObject.SetActive(false);
    }

    public override void onPickup(PlayerManager player)
    {
        player.transform.GetChild(child_index).gameObject.SetActive(true);
    }

    public override void holdingUpdate(PlayerManager player)
    {
        // When you need to update something
    }

    public override void holdingFixedUpdate(PlayerManager player)
    {
        // When you need to fixed update something
    }
}
