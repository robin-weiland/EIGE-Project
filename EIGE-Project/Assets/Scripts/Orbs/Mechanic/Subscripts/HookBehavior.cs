using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehavior : MonoBehaviour
{
    public PlayerManager origin;
    public float speed = 0.1f;
    public GameObject hit;
    public Vector2 collisionPos;
    private DistanceJoint2D joint;
    [SerializeField]
    private float pullSpeed = 0.05f;
    [SerializeField]
    private float maxDistance = 10f;
    public float offSet = 0f;
    private float minDistance = 0.5f;
    private float currentDistance = 0;
    private LineRenderer line;
    private Material mat;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        List<Material> result = new List<Material>();
        line.GetMaterials(result);
        mat = result[0];
        currentDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (line != null)
        {
            line.SetPosition(0, origin.transform.position);
            line.SetPosition(1, transform.position);
            mat.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
        }
    }

    private void FixedUpdate()
    {
        if (joint == null)
        {
            transform.position += transform.up * speed;
            currentDistance += speed;
            if (currentDistance > maxDistance) Destroy(gameObject);
        } 
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
