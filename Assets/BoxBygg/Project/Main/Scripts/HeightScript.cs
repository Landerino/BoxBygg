using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightScript : MonoBehaviour
{
    public GameObject Eyes;

    private float ScreenHeight = 0.1f;

    private void Start()
    {

    }
    void Update()
    {
        float playerHeight = Eyes.transform.position.y;

        float TargetScreenHeight = playerHeight - ScreenHeight;

        Vector3 screenPosition = transform.position;
        screenPosition.y = TargetScreenHeight;
        transform.position = screenPosition;
    }
}
