using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveBehab : MonoBehaviour
{
    private bool hot = false;
    public ParticleSystem particlesBooster;
    public ParticleSystem particles;

    private void Update()
    {
        transform.up = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
    }

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
            particlesBooster.Play();
            particles.Stop();
        }
        else
        {
            //deactivate particles
            particlesBooster.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            particles.Play();
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
