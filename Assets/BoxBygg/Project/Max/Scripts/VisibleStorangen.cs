using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleStorangen : MonoBehaviour
{
    public CanvasCaller CCaller;

    public GameObject Storangen;
    public GameObject Room;

    public void ShowHideStorangen()
    {
        if (!CCaller.IsShowing)
        {
            Storangen.SetActive(true);
            Room.SetActive(false);
            CCaller.IsShowing = true;
            CCaller.ShowHideCanvas();
        }
        else
        {
            Storangen.SetActive(false);
            Room.SetActive(true);
            CCaller.IsShowing = false;
            CCaller.ShowHideCanvas();
        }
    }
}
