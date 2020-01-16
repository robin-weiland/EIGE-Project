using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalBehavior : MonoBehaviour
{
    PlayerManager currentPlayer;
    [SerializeField]
    public bool hasOrb = true;
    [SerializeField]
    public float heightOffset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pickup
        if (Input.GetKeyDown(KeyCode.E) && currentPlayer != null && currentPlayer.properties.currentOrb != null && !hasOrb)
        {
            currentPlayer.properties.currentOrb.drop(this);
        }
    }


    public virtual void onOrbAdd(OrbBehavior orb)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPlayer = collision.gameObject.GetComponent<PlayerManager>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPlayer = null;
        }
    }
}
