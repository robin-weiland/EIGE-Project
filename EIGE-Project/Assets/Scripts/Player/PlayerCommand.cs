using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCommand
{
    public bool enabled = true;

    public abstract void run(PlayerManager player);

}
