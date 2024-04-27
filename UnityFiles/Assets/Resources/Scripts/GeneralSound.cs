using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class GeneralSound : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<StudioEventEmitter>().Play();
    }
}
