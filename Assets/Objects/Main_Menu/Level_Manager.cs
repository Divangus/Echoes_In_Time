using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public void Select_Level(int lvl)
    {
        SceneManager.LoadScene("Lvl_" + lvl);
        //Debug.Log("Lvl_" + lvl);
    }
}
