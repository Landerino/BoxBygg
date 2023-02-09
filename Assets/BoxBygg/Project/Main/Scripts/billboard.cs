using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    Camera cam;

    private void Update()
    {
        if (cam == null)
            cam = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        if (cam == null)
            return;

        transform.LookAt(cam.transform);
        transform.Rotate(Vector3.up * 180);
    }
}
