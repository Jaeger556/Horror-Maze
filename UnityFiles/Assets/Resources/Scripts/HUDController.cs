using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public Slider masterSlider;
    public float masterVolume;
    public static bool isPaused;
    public GameObject bear1;
    public GameObject bear2;
    public GameObject bear3;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }


        masterVolume = masterSlider.value;

        var emitters = FindObjectsOfType<FMODUnity.StudioEventEmitter>();
        foreach (var emitter in emitters)
        {
            emitter.SetParameter("MasterVolume", masterVolume);
        }

        switch (Pickup.bearCount)
        {
            case 1:
            bear1.SetActive(true);
            break;

            case 2:
            bear2.SetActive(true);
            break;

            case 3:
            bear3.SetActive(true);
            break;
        }
    }

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (F)";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    // Healthbar //
    [SerializeField] private Image healthbarSprite;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthbarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Paused()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void MasterVolume()
    {
        
    }
}
