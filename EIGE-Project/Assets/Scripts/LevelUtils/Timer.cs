﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time = 0;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        displayTimer(time);
    }
    public void displayTimer(float time)
    {
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("f2");

        if(float.Parse(seconds) < 10f)
        {
            string temp = "0";
            seconds = string.Concat(temp, seconds);
        }
        text.text = minutes + ":" + seconds;
    }
}
