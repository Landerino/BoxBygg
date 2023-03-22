using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CanvasCaller : MonoBehaviour
{
    public GameObject Sign;
    public GameObject Canvas;
    public bool IsShowing;

    void Start()
    {
        Canvas.SetActive(false);
        IsShowing = false;
        Sign.SetActive(false);
    }

    public void ShowHideCanvas()
    {
        if (IsShowing)
        {
            Canvas.SetActive(true);
        }
        else
        {
            Canvas.SetActive(false);
        }
    }

}
