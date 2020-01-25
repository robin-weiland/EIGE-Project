using UnityEngine;

public class Blade : MonoBehaviour
{

    public float rotationSpeed;
    public float rotation;
    
    

    // Update is called once per frame
    void Update()
    {
        var amtToMove = rotationSpeed * Time.deltaTime;
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotation, Space.World);
    }
}
