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
    public LayerMask isGround;

    [Range(1, 10)]
    public float jumpVelocity;

    public float jumpUpMultiplier;
    public float jumpDownMultiplier;

    // Orb
    public OrbBehavior currentOrb;

    // Respawn
    public Transform spawnPoint;
}
