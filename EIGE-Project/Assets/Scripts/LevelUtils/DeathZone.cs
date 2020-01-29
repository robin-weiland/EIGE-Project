using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject player; 

    public void Update()
    {
        this.transform.position = new Vector2(player.transform.position.x, -10f);
    }
    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //try other version using own scenemanager
        }
    }
}
