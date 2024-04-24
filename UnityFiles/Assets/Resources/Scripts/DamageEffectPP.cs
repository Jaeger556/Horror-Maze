using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageEffectPP : MonoBehaviour
{
    [SerializeField] private AttributeManager attManager;

    public float intensity = 0;

    PostProcessVolume volume;
    Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings<Vignette>(out vignette);

        if(!vignette)
        {
            Debug.Log("ERROR, vignette empty");
        }
        else
        {
            vignette.enabled.Override(false);
        }
    }

    public IEnumerator TakeDamageEffect()
    {
        intensity = 0.4f;

        vignette.enabled.Override(true);
        vignette.intensity.Override(0.4f);

        yield return new WaitForSeconds(0.4f);

        while (intensity > 0)
        {
            intensity -= 0.02f;

            if (intensity < 0) intensity = 0;

            vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.1f);
        }

        vignette.enabled.Override(false);
        yield break;
    }

    public void DamageCoroutine()
    {
        StartCoroutine(TakeDamageEffect());
    }
}
