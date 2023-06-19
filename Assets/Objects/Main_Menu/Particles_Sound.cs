using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles_Sound : MonoBehaviour
{
    public ParticleSystem sparks;
    public AudioSource sparks_audio;

    public float timer_Sparks;

    // Start is called before the first frame update
    void Start()
    {
        timer_Sparks = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer_Sparks > 0) { timer_Sparks -= Time.deltaTime; }
        else { timer_Sparks = 3; sparks.Play(); sparks_audio.Play(); }
    }
}
