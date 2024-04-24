using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Flashlight : MonoBehaviour
{
    private Light flight;
    private FMODUnity.StudioEventEmitter emitter;

    void Start()
    {
        flight = GetComponent<Light>();
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !HUDController.isPaused)
        {
            flight.enabled = !flight.enabled;
            emitter.Play();
        }
    }
}
