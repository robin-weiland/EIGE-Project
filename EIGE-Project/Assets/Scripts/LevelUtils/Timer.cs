using System.Collections;
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
        Debug.Log("Time: " + time);
        displayTimer(time);
    }
    public void displayTimer(float time)
    {
        string minutes = ((int)time / 50).ToString();
        string seconds = (time % 60).ToString();

        text.text = minutes + ":" + seconds;
    }
}
