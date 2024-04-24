using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.TestTools;

public class TestSuite
{    
    [UnityTest]
    public IEnumerator FlashlightClickOnOff()
    {
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        
        Light light = player.GetComponentInChildren<Light>(true);

        if(true)
        {
            light.enabled = !light.enabled;
        }
        
        if(true)
        {
            light.enabled = !light.enabled;
        }

        Object.Destroy(player);

        yield return null;
    }  
}
