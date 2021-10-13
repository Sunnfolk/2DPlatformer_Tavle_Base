using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer _audioMixer;
    public float musicVolume;
    

    void SetVolume(float value)
    {
        _audioMixer.SetFloat("MusicVol", value);
    }

    void GetVolume()
    {
        _audioMixer.GetFloat("MusicVol", out musicVolume);
    }

    public void ClearVolume()
    {
        _audioMixer.ClearFloat("MusicVol");
    }
    
}
