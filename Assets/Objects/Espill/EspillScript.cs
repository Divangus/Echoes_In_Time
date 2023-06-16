using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspillScript : MonoBehaviour
{ 
    [SerializeField]
    float destroyTime = 0.5f;

    bool destroying = false;

    private void Start()
    {
        //Duplicar i connectar objectes depenent del nivell (blackboard)
    }

    void Update()
    {
        if(destroying)
        {
            float alphaReduction = Time.deltaTime / destroyTime;
            gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, alphaReduction);
            Debug.Log(gameObject.GetComponent<SpriteRenderer>().color);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, destroyTime);
        if (!destroying) destroying = true;
    }
}
