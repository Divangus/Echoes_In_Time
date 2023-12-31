using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform soundWaveTransform;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("soundWave"))
        {
            LvlCompleted lc = FindObjectOfType<LvlCompleted>();
            if (lc == null) Debug.Log("LC non existance");
            else lc.PlayAudio(lc._Booster);

            other.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            //Get the booster direction
            Vector2 dir = transform.up;
            float force = 20f;

            other.GetComponent<SoundWaveBehab>().SetHot(true);
            other.isTrigger = true;

            //Boost the Soundwave
            other.transform.up = transform.up;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x * force, dir.y * force);
        }

    }
}
