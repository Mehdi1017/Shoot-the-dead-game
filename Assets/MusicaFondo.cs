using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicaFondo : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    private bool muted = false;

    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;

        }
        else
        {
            muted = false;
            AudioListener.pause = false;

        }
    }
}
