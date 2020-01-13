using UnityEngine;

public class DistanceMeasurement : MonoBehaviour
{
    public GameObject other;

    public float Get()
    {
        return Vector2.Distance(transform.position, other.transform.position);
    }
    
    public static float Get(GameObject start, GameObject end)
    {
        return Vector2.Distance(start.transform.position, end.transform.position);
    }
}
