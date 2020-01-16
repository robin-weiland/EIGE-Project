using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHoverScript: MonoBehaviour
{
    public float HoverStrength;
    public float HoverSpeed;
    float yposition;
    void Start()
    {
        yposition = this.transform.position.y;
    }

    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, yposition + (Mathf.Sin(Time.time * HoverSpeed) * HoverStrength));
    }
}
