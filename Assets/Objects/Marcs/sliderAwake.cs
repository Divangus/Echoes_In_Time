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

        //Add the slider to objects that have to been destroyed when the lvl is completed
        FindObjectOfType<LevelBlackBoard>().objectsToDestroy.Add(this.gameObject);

        //Don't reset Slider when reloading the scene
        DontDestroyOnLoad(this.gameObject); 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
