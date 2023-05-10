using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardScript : MonoBehaviour
{
    private bool IsOn;
    public GameObject Check;
    public GameObject Roof;

    void Start()
    {
        IsOn = false;
        Check.SetActive(false);
        Roof.SetActive(false);
    }

    public void Switch()
    {
        if (!IsOn)
        {
            Check.SetActive(true);
            IsOn = true;
        }
        else
        {
            Check.SetActive(false);
            IsOn = false;
        }
    }

    public void RemoveRoof()
    {
        if (IsOn)
        {
            Roof.SetActive(true);
        }
        else
        {
            Roof.SetActive(false);
        }
    }
}
