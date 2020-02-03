using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrb : MonoBehaviour
{
    [SerializeField]
    private Image up, orb, bar;

    [SerializeField]
    private List<OrbRef> orbs = new List<OrbRef>(1);

    private bool active = false;
    private float fill = 0;

    public void loadMechanic(OrbType id)
    {
        foreach (OrbRef orb in orbs)
        {
            if (orb.type == id)
            {
                up.sprite = orb.up;
                this.orb.sprite = orb.orb;
                bar.sprite = orb.bar;
            }
        }
    }

    public void setActive()
    {
        if (active) return;
        if (fill == 1) up.enabled = true;
        orb.enabled = true;
        bar.enabled = true;
        active = true;
    }

    public void setDisabled()
    {
        if (!active) return;
        up.enabled = false;
        orb.enabled = false;
        bar.enabled = false;
        active = false;
        bar.fillAmount = 0;
        fill = 0;
    }

    public void setFillStatus(float percent)
    {
        if (!active) setActive();
        bar.fillAmount = percent;
    }

    public void setFull()
    {
        setFillStatus(1);
        if (!active) setActive();
    }

    public void setUp(bool up)
    {
        this.up.enabled = up;
    }
}
