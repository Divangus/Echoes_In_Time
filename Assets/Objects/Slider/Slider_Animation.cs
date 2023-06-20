using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Animation : MonoBehaviour
{
    public Slider mainSlider;
    public Sprite[] newFrame;

    float set_time; //Time set by the player
    bool isPlaying; //Slider is working
    public bool _TimerOut; //Timer has finished

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            PlaySliderTime();
        }
    }

    public void Play()
    {
        isPlaying = true;
        set_time = mainSlider.value;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void PlaySliderTime()
    {
        if(mainSlider.value > 0)
        {
            //clock
            mainSlider.value -= Time.deltaTime;
        }
        else
        {
            //reset when finish
            isPlaying = false;
            _TimerOut = true;
        }
    }

    public void ResetValues()
    {
        mainSlider.value = set_time;
        isPlaying = false;
        _TimerOut = false;
    }
}
