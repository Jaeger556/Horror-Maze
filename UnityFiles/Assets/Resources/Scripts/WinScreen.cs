using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
   public void Exit()
   {
        Application.Quit();
   }

   public void Menu()
   {
        SceneManager.LoadSceneAsync("Main Menu");
   }
}
