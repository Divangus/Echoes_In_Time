using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBlackBoard : MonoBehaviour
{
    [SerializeField]
    private int level;

    public bool finalLevel;

    [Range(1, 3)]
    public int numberOfMaps = 1;

    public float distance = 100.0f;

    public int goalsReached = 0;

    public List<GameObject> objectsToDestroy = new List<GameObject>();

    private void Update()
    {
        if(goalsReached == numberOfMaps)
        {
            //Mark lvl as completed
            if (level > 0)
            {
                FindObjectOfType<LvlCompleted>().lvlCompleted[level - 1] = true;
            }
            else
            {
                FindObjectOfType<LvlCompleted>().lvlCompleted[level] = true;
            }

            // Get all the DontDestroyOnLoad objects of the actual scene

            
            if(finalLevel)
            {
                DestroyEverything();
                SceneManager.LoadScene("Main_Menu");
            }
            else
            {
                DestroyEverything();
                SceneManager.LoadScene("Lvl_" + (level + 1));
            }

        }
    }

    public void DestroyEverything()
    {
        // Destroy al cloned GO
        foreach (var obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}