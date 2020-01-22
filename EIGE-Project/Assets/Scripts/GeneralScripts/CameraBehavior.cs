using System.Collections;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    //Follow
    public GameObject player;
    private bool CameraStop;
    public float minX;
    public float maxX;

    //Shake
    private static CameraBehavior _instance;
    private Vector3 _originalPos;
    private float _timeAtCurrentFrame;
    private float _timeAtLastFrame;
    private float _fakeDelta;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        CameraStop = false;
    }
    void Update()
    {
        //Follow
        if(player.transform.position.x > minX && player.transform.position.x < maxX) {
            CameraStop = false;
        } else {
            CameraStop = true;
        }

        //CameraFollow X
        if (!CameraStop)
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, -10);
        }

        //CameraFollow Y is always active
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y + 2, -10);


        //Shake
        // Calculate a fake delta time, so we can Shake while game is paused.
        _timeAtCurrentFrame = Time.realtimeSinceStartup;
        _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
        _timeAtLastFrame = _timeAtCurrentFrame;

    }

    public static void Shake(float duration, float amount)
    {
        _instance._originalPos = _instance.gameObject.transform.localPosition;
        _instance.StopAllCoroutines();
        _instance.StartCoroutine(_instance._shake(duration, amount));
    }

    private IEnumerator _shake(float duration, float amount)
    {
        while (duration > 0)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;
            duration -= _fakeDelta;
            yield return null;
        }
        transform.localPosition = _originalPos;
    }
}
