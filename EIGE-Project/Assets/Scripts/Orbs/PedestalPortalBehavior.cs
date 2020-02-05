using UnityEngine;

public class PedestalPortalBehavior : PedestalBehavior
{
    [SerializeField]
    private GameObject portal;
    [SerializeField]
    private Timer timer;

    public override void onOrbAdd(OrbBehavior orb)
    {
        changeState(orb.type, true);
        if (this.tag.Equals("Last Pedestral")) //TAG IN FINAL LAST LEVEL THAT PEDESTRAL AS LAST ONE TO STOP THE TIMER
        {
            if (timer != null)
            {
                timer.stop();
            }
        }
    }

    public override void onOrbRemove(OrbBehavior orb)
    {
        changeState(orb.type, false);
    }

    private void changeState(OrbType type, bool state)
    {
        switch (type)
        {
            case OrbType.DoubleJump:
                portal.GetComponent<Animator>().SetBool("PortalBlue", state);
                break;
            case OrbType.Light:
                portal.GetComponent<Animator>().SetBool("PortalYellow", state);
                break;
            case OrbType.GravityLeft:
            case OrbType.GravityRight:
            case OrbType.GravityUp:
                portal.GetComponent<Animator>().SetBool("PortalPurple", state);
                break;
            default:
                if (state)
                {
                    // Default yellow portal
                    portal.GetComponent<Animator>().SetBool("PortalYellow", state);
                } else
                {
                    foreach (AnimatorControllerParameter parameter in portal.GetComponent<Animator>().parameters)
                    {
                        portal.GetComponent<Animator>().SetBool(parameter.name, false);
                    }
                }
                break;
        }
    }
}
