
public class OrbMechanic
{

    public OrbMechanic()
    {
    }

    public virtual void onPickup(PlayerManager player)
    {
    }

    public virtual void holdingFixedUpdate(PlayerManager player)
    {

    }

    public virtual void holdingUpdate(PlayerManager player)
    {
    }

    public virtual void onDrop(PlayerManager player)
    {
    }

    public static OrbMechanic GetOrbMechanic(OrbType type, OrbBehavior origin)
    {
        switch (type)
        {
            case OrbType.Test:
                return new TestMechanic();
            case OrbType.Light:
                return new LightMechanic();
            case OrbType.GravityRight:
                return new GravityMechanic(1, origin.gravityParticles);
            case OrbType.GravityUp:
                return new GravityMechanic(2, origin.gravityParticles);
            case OrbType.GravityLeft:
                return new GravityMechanic(3, origin.gravityParticles);
            case OrbType.Dash:
                return new DashMechanic(origin.dashAnchor, origin.dashArrow, origin.dashField);
            case OrbType.Projectile:
                return new ProjectileMechanic(origin.projectile);
            case OrbType.Pull:
                return new PullMechanic(origin.hook);
            case OrbType.DoubleJump:
                return new DoubleJumpMechanic();
            default:
                return new OrbMechanic();
        }
    }
}
