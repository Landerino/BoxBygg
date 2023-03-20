using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCaller : MonoBehaviour
{
    public GameObject Canvas;
    public bool IsShowing;

    void Start()
    {
        Canvas.SetActive(false);
        IsShowing = false;
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
