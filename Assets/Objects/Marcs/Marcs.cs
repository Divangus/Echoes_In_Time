using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcs : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] soundWaves;

    void Start()
    {
        soundWaves = GameObject.FindGameObjectsWithTag("soundWave"); // Get all the soundwaves of the scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If a soundwaves leave the screen -> reset the scene
        if (!collision.gameObject.activeInHierarchy) return;

        if (collision.CompareTag("soundWave"))
        {
            //PLay Audio Reset
            LvlCompleted lc = FindObjectOfType<LvlCompleted>();
            lc.PlayAudio(lc._lvlFail);

            for (int i = 0; i < soundWaves.Length; i++)
            {
                soundWaves[i].SetActive(false);
            }

            //Reset BB & Scene
            FindObjectOfType<LevelBlackBoard>().ResetValues();
            FindObjectOfType<LvlCompleted>().ChangeScene();
        }
            
    }
}
