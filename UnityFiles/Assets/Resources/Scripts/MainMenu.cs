using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject menuPanel;
    

    public void playButton()
    {
        SceneManager.LoadSceneAsync("MazeScene");
    }

    public void settingsButton()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive (false);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void backButton()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }


}
