using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainReset : MonoBehaviour
{
    [Header("THIS OBJECT MUST USE A TAG")]
    public int copies;
    public bool useNumberOfMaps;

    // Start is called before the first frame update
    void Awake()
    {
        if (CompareTag("Untagged")) Debug.Log("OBJECT NEEDS A TAG");

        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > ((useNumberOfMaps)? FindObjectOfType<LevelBlackBoard>().numberOfMaps: copies))
        {
            Destroy(this.gameObject);
        }

        //Add the slider to objects that have to been destroyed when the lvl is completed
        FindObjectOfType<LevelBlackBoard>().objectsToDestroy.Add(this.gameObject);

        //Don't reset Slider when reloading the scene
        DontDestroyOnLoad(this.gameObject);
    }
}
