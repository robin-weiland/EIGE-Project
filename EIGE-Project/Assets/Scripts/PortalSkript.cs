using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSkript : MonoBehaviour
{
    public GameObject Pedestal;
    void Update()
    {
        if (Pedestal.GetComponent<PedestalBehavior>().hasOrb == true) {
            name = Pedestal.transform.GetChild(1).gameObject.name;
            if (name == "CloudOrb") {
                this.GetComponent<Animator>().SetBool("PortalBlue", true);
            }
            else if (name == "LightOrb") {
                this.GetComponent<Animator>().SetBool("PortalYellow", true);
            }
            else if (name == "GravityOrb") {
                this.GetComponent<Animator>().SetBool("PortalPurple", true);

            }
        }

        if (Pedestal.GetComponent<PedestalBehavior>().hasOrb == false) {
            foreach (AnimatorControllerParameter parameter in this.GetComponent<Animator>().parameters)
            {
                this.GetComponent<Animator>().SetBool(parameter.name, false);
            }
        }
    }
}
