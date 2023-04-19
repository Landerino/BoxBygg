using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInTipArea : MonoBehaviour
{
    public GameObject Canvas;

    void Start()
    {
        Canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Canvas.SetActive(false);
        }
    }

}
