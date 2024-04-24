using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public static bool pIsDead = false;

    public void Exit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
