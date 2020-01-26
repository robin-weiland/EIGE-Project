using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
{
    private int child_index = 1;
    public GameObject player;
    [SerializeField]public OrbBehavior currentOrb;

    void Start()
    {

        currentOrb.type = OrbType.Light;
        player.transform.GetChild(child_index).gameObject.SetActive(true);
    }

}
