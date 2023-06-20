using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        if (CompareTag("Untagged")) Debug.Log("OBJECT NEEDS A TAG");

        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //Don't reset Blackboard when reloading the scene
        DontDestroyOnLoad(this.gameObject);
    }


    //Change Scene
    private void Update()
    {
        if(goalsReached == numberOfMaps)
        {
            LvlCompleted lc = FindObjectOfType<LvlCompleted>();
            lc.PlayAudio(lc._lvlComplete);

            //Mark lvl as completed
            if (level > 0)
            {
                lc.lvlCompleted[level - 1] = true;
            }

            if(finalLevel)
            {
                lc.ChangeScene("Main_Menu", true);
            }
            else
            {
                lc.ChangeScene("Lvl_" + (level + 1), true);
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

        Destroy(gameObject);
    }

    public void ResetValues()
    {
        goalsReached = 0;
        foreach(BallScript bs in FindObjectsOfType<BallScript>())
        {
            bs.ResetValues();
        }

        foreach (Slider_Animation sa in FindObjectsOfType<Slider_Animation>())
        {
            sa.ResetValues();
        }
    }
}