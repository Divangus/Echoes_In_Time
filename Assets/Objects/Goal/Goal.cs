using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool copia = false;

    private bool shake = false;

    [SerializeField]
    private float amount = 0.0f; //how much it shakes

    [SerializeField]
    private float time = 0.0f; //shake time

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
        if (shake)
        {
            Vector2 newPos = Random.insideUnitCircle * (Time.deltaTime * amount);

            transform.position += new Vector3(newPos.x, newPos.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("soundWave"))
        {
            //Play goal Particles
            gameObject.GetComponentInChildren<ParticleSystem>().Play();

            //Calculate shake to the goal

            //Shake Goal
            ShakeMe();

            

            //If a soundWave reach the goal, count it on the BB
            collision.gameObject.SetActive(false);
            FindObjectOfType<LevelBlackBoard>().goalsReached++;
        }
    }

    public void ShakeMe()
    {
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {
        Vector3 originalPos = transform.position;

        if(!shake) shake = true;

        yield return new WaitForSeconds(time);

        shake = false;

        transform.position = originalPos;
    }
}
