using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol);
    }
}
