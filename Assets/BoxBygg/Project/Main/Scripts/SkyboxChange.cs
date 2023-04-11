using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    public GameObject toggleObject;
    public Material onMaterial;
    public Material offMaterial;

    private bool isOn;
    private Material originalSkyboxMaterial;

    void Start()
    {
        // Save the original skybox material
        originalSkyboxMaterial = RenderSettings.skybox;
    }

    void Update()
    {
        // Check if the toggle object is active or not
        if (toggleObject.activeSelf && !isOn)
        {
            // Switch to the "on" material
            RenderSettings.skybox = onMaterial;
            isOn = true;
            Debug.Log("Skybox 2 is on");
        }
        else if (!toggleObject.activeSelf && isOn)
        {
            // Switch to the "off" material
            RenderSettings.skybox = originalSkyboxMaterial;
            isOn = false;
            Debug.Log("Skybox 1 is on");
        }
    }
}
