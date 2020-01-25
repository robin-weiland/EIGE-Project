using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Blade":
                GetComponent < Scenemanager>().reloadScene();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
        }
        
    }
}
