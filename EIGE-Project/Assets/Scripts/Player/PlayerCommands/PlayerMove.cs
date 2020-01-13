﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerCommand
{
    private bool facingLeft = true;
    public override void run(PlayerManager player)
    {
        player.rigidbody2D.velocity = new Vector2(player.properties.movementSpeed * Input.GetAxis("Horizontal"), player.rigidbody2D.velocity.y);

        //Animations
        player.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(player.rigidbody2D.velocity.x)*10);
        if (Input.GetAxis("Horizontal") > 0 && facingLeft == false){
            facingLeft = true;
            player.rigidbody2D.transform.Rotate(0, 180, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0&& facingLeft == true) {
            facingLeft = false;
            player.rigidbody2D.transform.Rotate(0, 180, 0);
        }
    }
}