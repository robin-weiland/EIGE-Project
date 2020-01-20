using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Header("SceneFade")]
    [SerializeField] [Range(0f, 10f)]
    public float fadeInLength;
    
    [SerializeField] [Range(0f, 10f)]
    public float fadeOutLength;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
        gameObject.GetComponent<Image>().CrossFadeAlpha(0f, fadeInLength, false);
    }

    private void OnDestroy()
    {
        gameObject.GetComponent<Image>().CrossFadeAlpha(1f, fadeOutLength, false);
        gameObject.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
    }
}
