using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    public Button[] button_List;

    public void Select_Level(int lvl)
    {
        //change scene
        SceneManager.LoadScene("Lvl_" + lvl);
    }

    public void Update_LevelSelect()
    {
        for (int i = 0; i < button_List.Length; i++)
        {
            //look all buttons, and change the color of the levels completed
            
            if (FindObjectOfType<LevelBlackBoard>().lvlCompleted[i])
            {
                button_List[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
