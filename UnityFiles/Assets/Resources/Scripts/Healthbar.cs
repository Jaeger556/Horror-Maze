using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Image healthbarSprite;
    public GameObject healthbar;


    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthbarSprite.fillAmount = currentHealth / maxHealth;

        if (LoseScreen.pIsDead == true)
        {
            healthbar.SetActive(false);
        }
    }
}
