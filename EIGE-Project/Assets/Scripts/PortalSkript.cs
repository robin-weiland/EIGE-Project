using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSkript : MonoBehaviour
{
    public GameObject Pedestal;
    void Update()
    {
        if (Pedestal.GetComponent<PedestalBehavior>().hasOrb == true) {
            this.GetComponent<Animator>().SetBool("Portal", true);
        }
    }
}
