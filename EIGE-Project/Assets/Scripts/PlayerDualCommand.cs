using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDualCommand : PlayerCommand
{
    public abstract void fixedRun(PlayerManager player);
}
