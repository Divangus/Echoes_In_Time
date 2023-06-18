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
            GameObject goal = Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent);
            Goal g = goal.GetComponent<Goal>();
            g.copia = true;

        }

        if (bb.numberOfMaps == 3)
        {
            //Create copies
            GameObject goal1 = Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent);
            GameObject goal2 = Instantiate(gameObject, transform.position + new Vector3(-bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent);

            //Get scripts
            EspillScript g1 = goal1.GetComponent<EspillScript>();
            EspillScript g2 = goal2.GetComponent<EspillScript>();
            g1.copia = true;
            g2.copia = true;

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
