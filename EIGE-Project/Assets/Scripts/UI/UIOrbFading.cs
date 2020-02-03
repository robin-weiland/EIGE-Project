using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrbFading : MonoBehaviour
{
    [SerializeField]
    private Image fading;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mathf.Sin(Time.time) / 4;
        Color w = Color.white;
        w.a = Mathf.Sin(Time.time * 2) / 4 + 0.75f;
        fading.color = w;
    }
}
