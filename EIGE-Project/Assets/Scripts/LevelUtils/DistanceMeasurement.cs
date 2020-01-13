using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMeasurement : MonoBehaviour
{
    private float _startEndDistance;
    public GameObject start, end;

    // Update is called once per frame
    private void Update()
    {
        _startEndDistance = Vector2.Distance(start.transform.position, end.transform.position);
    }
    
    public static float Get(GameObject start, GameObject end)
    {
        return Vector2.Distance(start.transform.position, end.transform.position);
    }

    public float Get()
    {
        return _startEndDistance;
    }
}
