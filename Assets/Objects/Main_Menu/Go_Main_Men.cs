using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_Main_Men : MonoBehaviour
{
   public void GoTo(string mainMenu)
    {
        // Destroy al cloned GO
        FindObjectOfType<LevelBlackBoard>().DestroyEverything();

        //change scene to the main menu
        SceneManager.LoadScene(mainMenu);
    }
}
