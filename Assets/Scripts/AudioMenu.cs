using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    public static AudioMenu instance;
    public AudioMixer Mixer;
    public Slider Master;
    public Slider Music;
    public Slider SFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetMusicVolumeMaster();
        SetMusicVolumeMusic();
        SetMusicVolumeSFX();
    }

    public void SetMusicVolumeMaster()
    {
        float volume = Master.value;
        Mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolumeMusic()
    {
        float volume = Music.value;
        Mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolumeSFX()
    {
        float volume = SFX.value;
        Mixer.SetFloat("SFX", Mathf.Log10(volume)* 20);
    }
}