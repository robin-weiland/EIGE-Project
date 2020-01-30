using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScene : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject pedestal;
    public Scenemanager scenemanager;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (pedestal.GetComponent<PedestalBehavior>().hasOrb)
        {
            if (player.tag == "Player")
            {
                scenemanager.switchSceneMainMenu();
            }
        }
    }
}

