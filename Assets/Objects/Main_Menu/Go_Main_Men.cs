using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_Main_Men : MonoBehaviour
{
   public void GoTo(string mainMenu)
   {
        //change scene to the main menu
        FindObjectOfType<LvlCompleted>().ChangeScene(mainMenu, true);

        //pause
        FindObjectOfType<LvlCompleted>().GetComponent<AudioSource>().Pause();
   }
}
