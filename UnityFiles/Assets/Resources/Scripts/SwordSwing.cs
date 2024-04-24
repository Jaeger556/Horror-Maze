using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    [SerializeField] GameObject sword;
    [SerializeField] AttributeManager attManager;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Swordswing());
        }
    }

    IEnumerator Swordswing()
    {
        sword.GetComponent<Animator>().Play("SwordSwing1");
        yield return new WaitForSeconds(1.0f);
        sword.GetComponent<Animator>().Play("New State");
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Enemy")
        {
            attManager.DealDamage(collider.gameObject);
            print(collider);
        }
    }
}
