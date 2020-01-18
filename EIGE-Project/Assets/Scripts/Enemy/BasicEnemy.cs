using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public GameObject player, patrol1, patrol2;
    private DistanceMeasurement playerDistance, patrol1Distance, patrol2Distance;

    private int gotoPatrol;
    // Start is called before the first frame update
    void Start()
    {
        gotoPatrol = 2;
        
        playerDistance = gameObject.AddComponent<DistanceMeasurement>();
        playerDistance.other = player;

        patrol1Distance = gameObject.AddComponent<DistanceMeasurement>();
        patrol1Distance.other = patrol1;

        patrol2Distance = gameObject.AddComponent<DistanceMeasurement>();
        patrol2Distance.other = patrol2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (gotoPatrol)
        {
            case 1:
                
                break;
            case 2:
                break;
            default:
                break;
        }
    }
}
