﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHover : MonoBehaviour
{

    //Works Like Basic Hover but 
    //  -needs a Second BoxCollider with checked onTriggerEnter on Object
    //  -starts at the most down position the platform ever reaches when moving => so it starts at its y position in the world - HoverStrength
    public float HoverStrength;
    public float HoverSpeed;
    private float yposition;
    private bool Elevator;
    void Start()
    {
        yposition = this.transform.position.y;
        this.transform.position = new Vector2(this.transform.position.x, yposition + HoverStrength);
    }

    void Update()
    {
        if (Elevator)
        {
            this.transform.position = new Vector2(this.transform.position.x, yposition + (Mathf.Cos(Time.time * HoverSpeed) * HoverStrength));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Elevator = true;
        }
    }
}
