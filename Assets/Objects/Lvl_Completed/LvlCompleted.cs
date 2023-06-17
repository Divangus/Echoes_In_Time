using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCompleted : MonoBehaviour
{
    public bool[] lvlCompleted;
    // Start is called before the first frame update

    void Awake()
    {
        if (CompareTag("Untagged")) Debug.Log("OBJECT NEEDS A TAG");

        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //Don't reset Slider when reloading the scene
        DontDestroyOnLoad(this.gameObject);
    }
}

