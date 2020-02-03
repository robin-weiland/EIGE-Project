using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer g;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (g == null)
        {
            g = this;
        } else
        {
            Destroy(gameObject);
        }
    }
}
