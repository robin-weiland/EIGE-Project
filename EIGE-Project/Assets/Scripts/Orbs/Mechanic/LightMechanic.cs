using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMechanic : OrbMechanic
{
    private GameObject light;
    public override void onDrop(PlayerManager player)
    {
        player.gameObject.GetComponentInChildren<Light>().gameObject.SetActive(false);
        //light = GameObject.Find("Player/Light");
        //light.gameObject.SetActive(false);
    }

    public override void onPickup(PlayerManager player)
    {
        player.gameObject.GetComponentInChildren<Light>().gameObject.SetActive(true);
        //light = GameObject.Find("Player/Light");
        //light.gameObject.SetActive(true);
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
