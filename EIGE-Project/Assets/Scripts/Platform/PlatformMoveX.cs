using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveX : MonoBehaviour
{
    //Works Like Basic Hover but 
    //  -needs a Second BoxCollider with checked onTriggerEnter on Object
    //  -starts at the most right position the platform ever reaches when moving => so it starts at its x position in the world - HoverStrength
    //  -but sideways
    public float HoverStrength;
    public float HoverSpeed;
    private float xposition;
    private bool Elevator;
    private float time;
    private bool active;
    void Start()
    {
        xposition = this.transform.position.x;
        this.transform.position = new Vector2(xposition + HoverStrength, this.transform.position.y);
        active = false;
    }

    void Update()
    {

        if (Elevator)
        {
            this.transform.position = new Vector2(xposition + (Mathf.Cos((Time.time - time) * HoverSpeed) * HoverStrength), this.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Elevator = true;
            if (!active)
            {
                active = true;
                time = Time.time;
            }
        }
    }
}
