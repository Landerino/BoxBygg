using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjectSync : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
