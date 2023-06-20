using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveBehab : MonoBehaviour
{
    private bool hot = false;
    public ParticleSystem particlesBooster;
    public ParticleSystem particles;
    public ParticleSystem particlesEspill;
    float t = 0.0f;
    public float particleTime; 

    private void Update()
    {
        transform.up = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        t += Time.deltaTime;
        if (t >= particleTime)
        {
            t -= particleTime;
            particles.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Espill")) return;
        particlesEspill.Play();
    }

    public void SetHot(bool value)
    {
        hot = value;

        if (value)
        {
            //activate particles
            particlesBooster.Play();
        }
        else
        {
            //deactivate particles
            particlesBooster.Stop(false, ParticleSystemStopBehavior.StopEmitting);
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
