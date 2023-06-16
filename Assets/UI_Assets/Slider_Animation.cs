using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Animation : MonoBehaviour
{
    public Slider mainSlider;
    public Sprite[] newFrame;

    public float time_left;
    //public Text  timer_Text;
    public bool playSlider;

    float lastFrame;

    // Start is called before the first frame update
    void Start()
    {
        lastFrame = mainSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(playSlider)
        {
            PlaySliderTime();
        }
    }

    public void PlaySliderTime()
    {
        if(time_left > 0)
        {
            //clock
            time_left -= Time.deltaTime;
            updateTimer();
        }
        else
        {
            //reset when finish
            playSlider = false;
            time_left = 3;
        }

    }

    public void updateTimer()
    {
        float currentTime = time_left;

        currentTime += 1;

        //set slider value
        mainSlider.value = ((currentTime * 4) % 60) - 4;

        //set text
        //timer_Text.text = string.Format("{0} seconds", Mathf.FloorToInt(currentTime % 60));
    }

    public void setTimer()
    {
        if(!playSlider)
        {
            float currentTime = mainSlider.value;

            if (mainSlider.value < lastFrame)
            {
                currentTime -= 1;
                //el +1 es xk sinó es passa dels limits i no funciona be
                mainSlider.value = currentTime + 1;
            }
            else if (mainSlider.value > lastFrame)
            {
                currentTime += 1;
                //el -1 es xk sinó es passa dels limits i no funciona be
                mainSlider.value = currentTime - 1;
            }

            //set text
            //timer_Text.text = string.Format("{0} seconds", (int)(currentTime * 0.25f));

            //set the time
            time_left = (currentTime * 0.25f);

            //set the last position
            lastFrame = mainSlider.value;
        }
    }

    public void SubmitSliderSetting()
    {
        float currentTime = time_left;

        currentTime += 1;
        //change sprite infunctuion of the slider position
        switch (Mathf.FloorToInt((currentTime * 4) % 60) - 4)
        {
            case 1:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 2:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 3:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 4:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 5:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 6:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 7:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 8:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 9:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 10:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 11:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 12:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 13:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            case 0:
                mainSlider.image.sprite = newFrame[((int)mainSlider.value)];
                break;
            default:
                mainSlider.image.sprite = newFrame[0];
                break;
        }
    }
}
