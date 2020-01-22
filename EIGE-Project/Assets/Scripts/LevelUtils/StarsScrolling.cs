using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScrolling : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 0.08f;
    public void Update()
    {
        float amtToMove = scrollSpeed * Time.deltaTime;
        transform.Translate(amtToMove * Vector3.right, Space.World);

        if (transform.position.x > -4)
        {
            transform.position = new Vector3(-48f, transform.position.y, transform.position.z);
        }
    }
}
