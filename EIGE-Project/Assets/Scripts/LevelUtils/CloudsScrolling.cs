using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsScrolling : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 2f;
    void Update()
    {
        float amtToMove = scrollSpeed * Time.deltaTime;
        transform.Translate(amtToMove * Vector3.right, Space.World);

        if (transform.position.x > 46f)
        {
            transform.position = new Vector3(-155f, transform.position.y, transform.position.z);
        }
    }
}
