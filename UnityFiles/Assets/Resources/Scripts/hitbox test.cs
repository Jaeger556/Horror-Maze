using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hitboxtest : MonoBehaviour
{
    [SerializeField] private AttributeManager attributeManager;
    

    void OnTriggerStay(Collider collider)
    {
        if(Input.GetKey(KeyCode.Mouse0) && collider.tag != "Player")
        {
            attributeManager.DealDamage(collider.gameObject);
            print(collider);
        }
    }

    /*void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Enemy" && gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            attributeManager.DealDamage(gameObject);
        }
    }*/
}
