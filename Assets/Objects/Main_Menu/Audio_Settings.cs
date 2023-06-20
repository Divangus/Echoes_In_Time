using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float vol)
    {
        var dbVolume = Mathf.Log10(vol) * 20;
        //ajust the volume mixer
        if (vol == 0.0f)
        {
            dbVolume = -80.0f;
        }
        audioMixer.SetFloat("volume", dbVolume);

        Debug.Log(dbVolume);
    }
}
