using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour
{
    public OrbMechanic mechanic;
    [SerializeField]
    public OrbType type = OrbType.NoEffect;
    private bool pickedUp = false;
    private bool playerInRange = false;
    private PlayerManager currentPlayer;

    public PedestalBehavior currentPedestal;

    private int current = 20;
    [SerializeField]
    private int cooldown = 5;

    // Start is called before the first frame update
    void Start()
    {
        mechanic = OrbMechanic.GetOrbMechanic(type);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current > 0) current--;
        if (!pickedUp) {
            if (Input.GetKeyDown(KeyCode.E) && playerInRange && current == 0 && currentPlayer.properties.currentOrb == null)
            {
                // Drop
                Camera.Shake(0.4f, 0.25f);
                currentPlayer.properties.currentOrb = this;
                // Disable orb
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                foreach (Transform child in transform)
                    child.gameObject.SetActive(false);
                // Event
                mechanic.onPickup(currentPlayer);
                current = cooldown;
                pickedUp = true;
                if (currentPedestal != null)
                {
                    currentPedestal.hasOrb = false;
                    currentPedestal = null;
                }
            }
        }
    }

    public void drop(PedestalBehavior pedestal)
    {
        if (pickedUp && current == 0)
        {
            Camera.Shake(0.4f, 0.25f);
            mechanic.onDrop(currentPlayer);
            pedestal.onOrbAdd(this);
            currentPlayer.properties.currentOrb = null;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            pickedUp = false;
            current = cooldown;
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);
            currentPedestal = pedestal;
            this.transform.SetParent(currentPedestal.transform);

            transform.localPosition = transform.up * pedestal.heightOffset;
            pedestal.hasOrb = true;
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
