using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    public Scenemanager scenemanager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Blade":
                Physics2D.gravity = new Vector2(0, -9.8f);
                scenemanager.reloadScene();
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
