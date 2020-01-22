using UnityEngine;

public class PortalSkript : MonoBehaviour
{
    private Scenemanager scenemanager;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LightOrb")
        {
            scenemanager.switchSceneToLevel(3);
        }
        //Do the same Thing for each level added; watch BuildManager for scene-info
    }
}
