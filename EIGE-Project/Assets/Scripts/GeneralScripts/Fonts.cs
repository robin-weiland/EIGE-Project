using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fonts : MonoBehaviour
{
    Color newcolor;
    public Text newtext;
    private void Start()
    {
        InvokeRepeating("changeColor", 0f, 1.0f);
    }
    void Update()
    {
        //changeColor();
    }
    public void changeColor()
    {
        byte red = (byte)Random.Range(10, 240);
        byte green = (byte)Random.Range(10, 240);
        byte blue = (byte)Random.Range(10, 240);
        byte alpha = (byte)Random.Range(10, 240);
        newtext.material.color = new Color(red, green, blue, alpha);
    }
}
