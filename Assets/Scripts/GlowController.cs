using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlowController : MonoBehaviour
{
    public Material glowingMaterial;
    public Volume bloomVolume;
    private Bloom bloomEffect;

    private void Start()
    {
        bloomEffect = null;
        bloomVolume.profile.TryGet(out bloomEffect);
        DeactivateGlow(); // Deactivate glow initially
    }

    // Method to activate the glowing effect
    public void ActivateGlow()
    {
        glowingMaterial.EnableKeyword("_EMISSION");
        bloomEffect.intensity.value = 10f; // Set the desired intensity for the Bloom effect
        bloomVolume.gameObject.SetActive(true);
    }

    // Method to deactivate the glowing effect
    public void DeactivateGlow()
    {
        glowingMaterial.DisableKeyword("_EMISSION");
        bloomVolume.gameObject.SetActive(false);
    }
}
