using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalBehavior : MonoBehaviour
{
    PlayerManager currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && currentPlayer != null && currentPlayer.properties.currentOrb != null)
        {
            BoxCollider2D orbCollider = currentPlayer.properties.currentOrb.GetComponent<BoxCollider2D>();
            BoxCollider2D currentCollider = GetComponent<BoxCollider2D>();
            currentPlayer.properties.currentOrb.drop(new Vector3(
                transform.position.x, 
                transform.position.y + currentCollider.size.y * transform.localScale.y / 2 + orbCollider.size.y * currentPlayer.properties.currentOrb.transform.localScale.y / 2, 
                transform.position.z));
        }
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
