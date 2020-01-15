using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Header("SceneFade")]
    [SerializeField] 
    public Image fader;
    
    [SerializeField] [Range(1f, 10f)]
    public float fadeInLength;
    
    [SerializeField] [Range(1f, 10f)]
    public float fadeOutLength;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.GetType());
        fader.canvasRenderer.SetAlpha(1f);
        fader.CrossFadeAlpha(0f, fadeInLength, false);
    }

    private void OnDestroy()
    {
        fader.CrossFadeAlpha(1f, fadeOutLength, false);
        fader.canvasRenderer.SetAlpha(1f);
    }
}
