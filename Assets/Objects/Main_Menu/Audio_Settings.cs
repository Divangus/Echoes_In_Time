using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio_Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        float mixerValue;
        audioMixer.GetFloat("volume", out mixerValue);
        if (mixerValue == -80.0f) GetComponent<Slider>().value = 0.0f;
        else
        {
            GetComponent<Slider>().value = Mathf.Pow(10, mixerValue / 20.0f);
        }
    }

    public void SetVolume(float vol)
    {
        var dbVolume = Mathf.Log10(vol) * 20;
        //ajust the volume mixer
        if (vol == 0.0f)
        {
            dbVolume = -80.0f;
        }
        audioMixer.SetFloat("volume", dbVolume);
    }
}
