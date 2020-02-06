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

    public void OnTriggerEnter2D(Collider2D player) //switching to next level after portal opening
    {
        if (pedestal.GetComponent<PedestalBehavior>().hasOrb)
        {
            if (player.tag == "Player")
            {
                if (scenemanager.returnCurrentScene().buildIndex.Equals(2))
                {
                    scenemanager.switchSceneToLevel(3);
                }
                if (scenemanager.returnCurrentScene().buildIndex.Equals(3))
                {
                    scenemanager.switchSceneToLevel(4);
                }
                if (scenemanager.returnCurrentScene().buildIndex.Equals(4))
                {
                    scenemanager.switchSceneMainMenu(); //switch to main menu after finishing
                }
                //add additional levels to switch here
            }
        }
    }
}

