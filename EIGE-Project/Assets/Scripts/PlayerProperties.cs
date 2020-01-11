using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProperties
{
    [SerializeField]
    public float movementSpeed;
    [Range(1, 10)]
    public float jumpVelocity;

}
