using UnityEngine;

public class SideHoverScript : MonoBehaviour
{
    public float HoverStrength;
    public float HoverSpeed;
    private Vector2 startingPos;
    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        this.transform.position = startingPos + (Vector2)transform.up * (Mathf.Sin(Time.time * HoverSpeed) * HoverStrength);
    }
}