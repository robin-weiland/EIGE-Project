using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehavior : MonoBehaviour
{
    public PlayerManager origin;
    public float speed = 0.5f;
    public GameObject hit;
    public Vector2 collisionPos;
    private DistanceJoint2D joint;
    private float pullSpeed = 0.05f;
    private float minDistance = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (joint == null) transform.position += transform.up * speed;
        else joint.distance = Mathf.Max(joint.distance - pullSpeed, minDistance);
    }

    private void OnDestroy()
    {
        if (joint != null)
        {
            joint.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            hit = collision.gameObject;
            collisionPos = transform.position;

            DistanceJoint2D temp = origin.GetComponent<DistanceJoint2D>();
            if (temp == null)
            {
                joint = origin.gameObject.AddComponent<DistanceJoint2D>();
            } else
            {
                joint = temp;
            }
            joint.enabled = true;
            joint.enableCollision = true;

            Rigidbody2D otherBody = collision.GetComponent<Rigidbody2D>();
            if (otherBody != null)
            {
                joint.connectedBody = otherBody;
                joint.distance = Vector2.Distance(origin.transform.position, otherBody.position);
                joint.connectedAnchor = Vector2.zero;
            }
            else
            {
                joint.connectedAnchor = collisionPos;
                joint.distance = Vector2.Distance(origin.transform.position, collisionPos);
                joint.connectedBody = null;
            }
            joint.autoConfigureDistance = false;
        }
    }
}
