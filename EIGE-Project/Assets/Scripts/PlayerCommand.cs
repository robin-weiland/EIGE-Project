using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerCommand
{
    void run(PlayerManager player);
}
