using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveBehab : MonoBehaviour
{
    private bool hot = false;

    private void OnCollisionEnter(Collision collision)
    {
        //PARTICLES
    }

    public void SetHot(bool value)
    {
        hot = value;

        if (value)
        {
            //activate particles
        }
        else
        {
            //deactivate particles
        }
    }

    public bool isHot()
    {
        return hot;
    }
}
