using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZoneAdaptive : MonoBehaviour
{
    [SerializeField]
    private float posX = 0;
    [SerializeField]
    private float posY = 0;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = new Vector2(
            posX == 0 ? player.transform.position.x : posX,
            posY == 0 ? player.transform.position.y : posY);
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            // Reset Gravity
            Physics2D.gravity = new Vector2(0, -9.8f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //try other version using own scenemanager
        }
    }
}
