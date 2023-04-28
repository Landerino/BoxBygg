using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material[] hairMaterials;
    public Material[] shirtMaterials;

    private int selectedHairIndex = 0;
    private int selectedShirtIndex = 0;

    private const string HairColorKey = "HairColorIndex";
    private const string ShirtColorKey = "ShirtColorIndex";

    private void Start()
    {
        selectedHairIndex = PlayerPrefs.GetInt(HairColorKey, 0);
        selectedShirtIndex = PlayerPrefs.GetInt(ShirtColorKey, 0);

        ChangeHairMaterial(hairMaterials[selectedHairIndex]);
        ChangeShirtMaterial(shirtMaterials[selectedShirtIndex]);
    }

    public void ChangeHairMaterial(Material newMaterial)
    {
        selectedHairIndex = System.Array.IndexOf(hairMaterials, newMaterial);

        GameObject[] hairObjects = GameObject.FindGameObjectsWithTag("Hair");
        foreach (GameObject hairObject in hairObjects)
        {
            Renderer renderer = hairObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }

        PlayerPrefs.SetInt(HairColorKey, selectedHairIndex);
    }

    public void ChangeShirtMaterial(Material newMaterial)
    {
        selectedShirtIndex = System.Array.IndexOf(shirtMaterials, newMaterial);

        GameObject[] shirtObjects = GameObject.FindGameObjectsWithTag("Shirt");
        foreach (GameObject shirtObject in shirtObjects)
        {
            Renderer renderer = shirtObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }

        PlayerPrefs.SetInt(ShirtColorKey, selectedShirtIndex);
    }
}