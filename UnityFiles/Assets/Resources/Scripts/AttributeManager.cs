using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private HUDController HUDController;
    [SerializeField] private Healthbar enemyHealthbar;
    private float currentHealth;
    //private int pAttack = 25;
    private float eAttack  = 33.5f;

    public GameObject pp;
    public GameObject panel;
    public GameObject monster;

    void Start()
    {
        //Health set to max
        currentHealth = maxHealth;

        HUDController.UpdateHealthBar(maxHealth, currentHealth);
        //enemyHealthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void Update()
    {
        if(currentHealth < 0)
        {
            Destroy(gameObject);
            LoseScreen.pIsDead = true;
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(monster);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        HUDController.UpdateHealthBar(maxHealth, currentHealth);
    }

    public void EnemyDamage(int amount)
    {
        currentHealth -= amount;
        enemyHealthbar.GetComponent<Healthbar>();
        enemyHealthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    public void DealDamage(GameObject target)
    {
        var temp = target.GetComponent<AttributeManager>();

        if(temp.CompareTag("Player"))
        {
            print("damage player");
            temp.TakeDamage(eAttack);

            var damageEffectPP = pp.GetComponent<DamageEffectPP>();
            damageEffectPP.DamageCoroutine();
        }
        else
        {
            Debug.Log("No target found");
        }
    }
}
