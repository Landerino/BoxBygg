using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtChanger : MonoBehaviour
{
    public GameObject Shirt;
    public GameObject Hair;
    
    public int ShirtColor;
    public int HairColor;

    public Material[] Colors;
    public Material[] HairColors;

    Renderer Rend;

    public void Updatecolor()
    {
        Rend = Shirt.GetComponent<Renderer>();
        Rend.material = Colors[ShirtColor];
    }

    public void UpdateHair()
    {
        Rend = Hair.GetComponent<Renderer>();
        Rend.material = HairColors[HairColor];
    }
}
