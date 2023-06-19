using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspillScript : MonoBehaviour
{ 
    [SerializeField]
    float destroyTime = 0.5f;
    bool destroying = false;

    public bool copia = false;
    public EspillScript[] brothers;

    private void Start()
    {
        if (copia) return;

        //Duplicar i connectar objectes depenent del nivell

        LevelBlackBoard bb = FindObjectOfType<LevelBlackBoard>();

        if(bb.numberOfMaps == 2)
        {
            //Create copies
            GameObject mirall = Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent);
            EspillScript es = mirall.GetComponent<EspillScript>();
            es.copia = true;

            //Set brothers in all 2 mirrors
            brothers = new EspillScript[] { es };
            es.brothers = new EspillScript[] { this };
        }

        if (bb.numberOfMaps == 3)
        {
            //Create copies
            GameObject mirall1 = Instantiate(gameObject, transform.position + new Vector3(bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent);
            GameObject mirall2 = Instantiate(gameObject, transform.position + new Vector3(-bb.distance, 0.0f, 0.0f), transform.rotation, transform.parent);
            
            //Get scripts
            EspillScript es1 = mirall1.GetComponent<EspillScript>();
            EspillScript es2 = mirall2.GetComponent<EspillScript>();
            es1.copia = true;
            es2.copia = true;

            //Set brothers in all 3 mirrors
            brothers = new EspillScript[] { es1, es2 };
            es1.brothers = new EspillScript[] { this, es2 };
            es2.brothers = new EspillScript[] { this, es1 };
        }
    }

    void Update()
    {
        if(destroying)
        {
            gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime / destroyTime);
        }
    }

    void Disapear()
    {
        Destroy(gameObject, destroyTime);
        if (!destroying) destroying = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("soundWave")) return;

        //kill all objects
        foreach(EspillScript obj in brothers)
        {
            obj.Disapear();
        }
        Disapear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("soundWave")) return;

        collision.gameObject.GetComponent<SoundWaveBehab>().SetHot(false);

        foreach (EspillScript obj in brothers)
        {
            Destroy(obj.gameObject);
        }
        Destroy(gameObject);

        

        collision.isTrigger = false;
    }
}
