using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProperties
{
    //Move
    [SerializeField]
    [Header("Movement")]
    public float movementSpeed;

    //Jump
    [Header("Jump")]
    public Transform feetPosition;
    
    
    public float isGroundedCircleRadius;
    public LayerMask isGround;

    [Range(1, 10)]
    public float jumpVelocity;

    public float jumpUpMultiplier;
    public float jumpDownMultiplier;

    // Orb
    [Header("Orb")]
    public OrbBehavior currentOrb;

    // Respawn
    [Header("Spawn")]
    public Transform spawnPoint;
}
