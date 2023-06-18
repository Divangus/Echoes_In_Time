using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool copia = false;

    // Start is called before the first frame update
    void Start()
    {
        if (copia) return;

        //Duplicar objectes depenent del nivell

        LevelBlackBoard bb = FindObjectOfType<LevelBlackBoard>();

        if (bb.numberOfMaps == 2)
        {
            //Create copies
            Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent).
                GetComponent<Goal>().copia = true;
        }

        if (bb.numberOfMaps == 3)
        {
            //Create copies
            Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent).
                GetComponent<Goal>().copia = true;
            Instantiate(gameObject, transform.position + new Vector3(-bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent).
                GetComponent<Goal>().copia = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("soundWave"))
        {
            //If a soundWave reach the goal, count it on the BB
            collision.gameObject.SetActive(false);
            FindObjectOfType<LevelBlackBoard>().goalsReached++;
        }
    }
}
