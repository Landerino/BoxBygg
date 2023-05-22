using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CanvasCaller : MonoBehaviour
{
    public GameObject Sign;
    public GameObject Canvas;
    public GameObject BoardC1;
    public GameObject BoardC2;
    public GameObject BoardC3;
    public GameObject BoardC4;
    public bool IsShowing;

    void Start()
    {
        Canvas.SetActive(false);
        BoardC1.SetActive(false);
        BoardC2.SetActive(false);
        BoardC3.SetActive(false);
        BoardC4.SetActive(false);
        IsShowing = false;
        Sign.SetActive(false);
    }

    public void ShowHideCanvas()
    {
        if (IsShowing)
        {
            Canvas.SetActive(true);
            BoardC1.SetActive(true);
            BoardC2.SetActive(true);
            BoardC3.SetActive(true);
            BoardC4.SetActive(true);
        }
        else
        {
            Canvas.SetActive(false);
            BoardC1.SetActive(false);
            BoardC2.SetActive(false);
            BoardC3.SetActive(false);
            BoardC4.SetActive(false);
        }
    }

}
