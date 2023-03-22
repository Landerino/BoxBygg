using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasketPointCounter : MonoBehaviour
{
    public TextMeshProUGUI PointsText;
    private int Points;

    void Start()
    {
        Points = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Points++;
            UpdatePoints();
        }
    }

    private void UpdatePoints()
    {
        PointsText.text = Points.ToString();
    }
}
