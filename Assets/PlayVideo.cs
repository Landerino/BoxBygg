using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    private bool isOn;
    public GameObject Screen;
    public GameObject text;

    void Start()
    {
        isOn = false;
        Screen.SetActive(false);
        text.SetActive(true);
    }

    public void TurnOnOff()
    {
        if (!isOn)
        {
            text.SetActive(false);
            Screen.SetActive(true);
            isOn = true;
        }
        else
        {
            Screen.SetActive(false);
            text.SetActive(true);
        }
    }

}
