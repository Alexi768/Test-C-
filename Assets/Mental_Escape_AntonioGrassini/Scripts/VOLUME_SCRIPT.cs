using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VOLUME_SCRIPT : MonoBehaviour
{
    Slider Slider;
    public AudioSource Audio;
    // Use this for initialization
    void Start()
    {
        Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Audio.volume = Slider.value;
    }
    public float VolumeAudio()
    {
        Audio.volume = Slider.value;
        return Audio.volume;
    }
}
