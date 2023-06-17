using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBlackBoard : MonoBehaviour
{
    [SerializeField]
    private int level;

    [Range(1, 3)]
    public int numberOfMaps = 1;

    public float distance = 100.0f;

    public int goalsReached = 0;

    public List<GameObject> objectsToDestroy = new List<GameObject>();

    Level_Manager lvl_Manager;

    private void Update()
    {
        if(goalsReached == numberOfMaps)
        {
            // Get all the DontDestroyOnLoad objects of the actual scene
            
            // Destroy al cloned GO
            foreach (var obj in objectsToDestroy)
            {
               Destroy(obj);
            }

            lvl_Manager.lvlCompleted[level] = true;
            SceneManager.LoadScene("Lvl_" + (level+1));
        }
    }
}