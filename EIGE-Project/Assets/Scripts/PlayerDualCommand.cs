using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerDualCommand
{
    void run(PlayerManager player);

    void fixedRun(PlayerManager player);
}
