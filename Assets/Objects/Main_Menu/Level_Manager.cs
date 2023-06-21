using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    public Button[] button_List;

    public void Select_Level(int lvl)
    {
        FindObjectOfType<LvlCompleted>().ChangeScene("Lvl_" + lvl);

        FindObjectOfType<LvlCompleted>().GetComponent<AudioSource>().Play();
        //play
    }

    public void Update_LevelSelect()
    {
        for (int i = 0; i < button_List.Length; i++)
        {
            //look all buttons, and change the color of the levels completed
            
            if (FindObjectOfType<LvlCompleted>().lvlCompleted[i])
            {
                button_List[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
