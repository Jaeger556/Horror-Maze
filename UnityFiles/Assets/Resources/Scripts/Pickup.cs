using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public StudioEventEmitter emitter1;
    public StudioEventEmitter emitter2;
    public StudioEventEmitter emitter3;
    public static int bearCount = 0;

    public GameObject wincam;
    public GameObject maincam;
    public GameObject deathcam;


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            bearCount++;
            switch(bearCount)
            {
                case 1:
                    Debug.Log("bearsound1");
                    emitter1.Play();
                    break;
                case 2:
                    emitter2.Play();
                    break;
                case 3:
                    emitter3.Play();
                    maincam.SetActive(false);
                    wincam.SetActive(true);
                    deathcam.SetActive(false);
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
