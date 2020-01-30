using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    public Scenemanager scenemanager;

    public void Update()
    {
        this.transform.position = new Vector2(player.transform.position.x, -10f);
    }
    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            scenemanager.reloadScene();
        }
    }
}
