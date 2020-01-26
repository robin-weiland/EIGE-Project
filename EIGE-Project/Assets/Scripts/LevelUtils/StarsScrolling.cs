using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScrolling : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 0.08f;
    float originalX;

    public void Start()
    {
        originalX = this.transform.position.x;
    }
    public void Update()
    {
        float amtToMove = scrollSpeed * Time.deltaTime;
        this.transform.Translate(amtToMove * Vector3.right, Space.World);

        if (this.transform.position.x < originalX - 4)
        {
            this.transform.position = new Vector3(originalX, this.transform.position.y, this.transform.position.z);
        }
    }
}
