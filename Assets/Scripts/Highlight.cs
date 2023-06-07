using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color = Color.white;

    //Helper list to cache all materials of this object
    private List<Material> materials;

    //Gets all the materials from each renderer
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            //a single child object might have multiple materials on it
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach (var material in materials)
            {
                //we need to enable the emmission
                material.EnableKeyword("_EMISSION");
                //before we can set the colour
                material.SetColor("_EmissionColor", color);
            }
        }
        else
        {
            foreach (var material in materials)
            {
                //we can disable the emission if we dont use emission colors anywhere else
                material.DisableKeyword("_EMISSION");
            }
        }
    }

}