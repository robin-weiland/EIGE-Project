using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour
{
    public OrbMechanic mechanic;
    [SerializeField]
    public OrbType type;
    private bool pickedUp = false;
    private bool playerInRange = false;
    private PlayerManager currentPlayer;

    [SerializeField]
    private int current = 20;
    private int cooldown = 5;

    // Start is called before the first frame update
    void Start()
    {
        mechanic = new OrbMechanic(type);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current > 0) current--;
        if (!pickedUp) {
            if (Input.GetKeyDown("e") && playerInRange && current == 0 && currentPlayer.properties.currentOrb == null)
            {
                currentPlayer.properties.currentOrb = this;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                mechanic.onPickup(currentPlayer);
                current = cooldown;
                pickedUp = true;
                foreach (Transform child in transform)
                    child.gameObject.SetActive(false);
            }
        }
    }

    public void drop(Vector3 position)
    {
        if (pickedUp && current == 0)
        {
            transform.position = position;
            mechanic.onDrop(currentPlayer);
            currentPlayer.properties.currentOrb = null;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            pickedUp = false;
            current = cooldown;
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPlayer = collision.gameObject.GetComponent<PlayerManager>();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
