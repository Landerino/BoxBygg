using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtChanger : MonoBehaviour
{
    public GameObject Shirt;
    
    public int ShirtColor;

    public Material[] Colors;

    Renderer Rend;

    public void Updatecolor()
    {
        Rend = Shirt.GetComponent<Renderer>();
        Rend.material = Colors[ShirtColor];
    }
}
