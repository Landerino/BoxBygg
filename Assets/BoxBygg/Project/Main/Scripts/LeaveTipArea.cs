using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTipArea : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
