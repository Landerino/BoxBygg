using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSpawner : MonoBehaviour
{
    public int ShowDate;

    public GameObject Sign;

    public UITimeScript TimeCanvas;

    void Update()
    {
        if (TimeCanvas.Date >= ShowDate)
        {
            Sign.SetActive(true);
        }
        else Sign.SetActive(false);
    }
    private void Start()
    {
        Sign.SetActive(false);
    }
}
