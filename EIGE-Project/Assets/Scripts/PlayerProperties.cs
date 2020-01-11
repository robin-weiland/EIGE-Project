using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProperties
{
    //Move
    [SerializeField]
    public float movementSpeed;

    //Jump
    public Transform feetPosition;

    public float isGroundedCircleRadius;

    [Range(1, 10)]
    public float jumpVelocity;

    public float maxJumpTime;

    public LayerMask isGround;



}
