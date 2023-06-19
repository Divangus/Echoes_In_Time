using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveBehab : MonoBehaviour
{
    private bool hot = false;
    public ParticleSystem particles;

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
            particles.Play();
        }
        else
        {
            //deactivate particles
            particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            ResetSpeed();
        }
    }

    public bool isHot()
    {
        return hot;
    }

    public void ResetSpeed()
    {
        float ballSpeed = FindObjectOfType<BallScript>()._ballSpeed;
        Vector2 dir = transform.up;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x * ballSpeed, dir.y * ballSpeed);
    }
}
