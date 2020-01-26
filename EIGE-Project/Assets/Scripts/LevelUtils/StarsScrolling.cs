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
        this.transform.Translate(amtToMove * Vector3.right, Space.World);

        if (this.transform.position.x > -4)
        {
            this.transform.position = new Vector3(-48f, this.transform.position.y, this.transform.position.z);
        }
    }
}
