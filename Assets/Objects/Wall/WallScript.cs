using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public bool copia = false;

    private void Start()
    {
        if (copia) return;

        LevelBlackBoard bb = FindObjectOfType<LevelBlackBoard>();

        if (bb.numberOfMaps == 2)
        {
            //Create copies
            Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent).
                GetComponent<WallScript>().copia = true;
        }

        if (bb.numberOfMaps == 3)
        {
            //Create copies
            Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent).
                GetComponent<WallScript>().copia = true;
            Instantiate(gameObject, transform.position + new Vector3(-bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent).
                GetComponent<WallScript>().copia = true;
        }
    }
}