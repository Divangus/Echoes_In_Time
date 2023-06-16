using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderAwake : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Slider");

        if (objs.Length > FindObjectOfType<LevelBlackBoard>().numberOfMaps)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject); //Don't reset Slider when reloading the scene
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
