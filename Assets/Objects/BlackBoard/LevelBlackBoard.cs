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


    private void Update()
    {
        Debug.Log(goalsReached);

        if(goalsReached == numberOfMaps)
        {
            //TODO: Destroy all DontDestroyOnLoad
            // Obtén todos los objetos de DontDestroyOnLoad en la escena actual

            // Destruye los objetos duplicados encontrados
            foreach (var obj in objectsToDestroy)
            {
               Destroy(obj);
            }
            SceneManager.LoadScene("Lvl_" + (level+1));
        }
    }
}