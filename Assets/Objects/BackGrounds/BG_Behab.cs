using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Behab : MonoBehaviour
{
    private Color light;

    private bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.Find("light").gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            light.a += Time.deltaTime;
            if (light.a > 0.9f) up = false;
        }
        else
        {
            light.a -= Time.deltaTime;
            if (light.a < 0.1f) up = true;
        }
        //TODO doesn't change
    }
}
