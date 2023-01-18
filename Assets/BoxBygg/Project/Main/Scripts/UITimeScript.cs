using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimeScript : MonoBehaviour
{

    public TextMeshProUGUI text;
    public Image TimeBar;
    public GameObject butnJoin;

    private int Date;
    private float desiredDuration = 25f;
    private float elapsedTime;
    private float FillWant;
    private bool TimerOn;

    void Start()
    {
        Date = 2021;
        TimerOn = false;
        FillWant = 1;
        TimeBar.fillAmount = 0;
        text.text = Date.ToString();
    }


    void Update()
    {
        if (TimerOn)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            TimeBar.fillAmount = Mathf.Lerp(0, FillWant, percentageComplete);
            text.text = Date.ToString();
            if (TimeBar.fillAmount < 0.29)
            {
                Date = 2021;
            }
            else if (TimeBar.fillAmount > 0.29 && TimeBar.fillAmount < 0.493)
            {
                Date = 2022;
            }
            else if (TimeBar.fillAmount > 0.493 && TimeBar.fillAmount < 0.71)
            {
                Date = 2023;
            }
            else 
            { Date = 2024; }
        }
        if (TimeBar.fillAmount > 0.99f) butnJoin.SetActive(true);
            else butnJoin.SetActive(false);
    }

    public void StartTime()
    {
        if (!TimerOn)
            TimerOn = true;
        else TimerOn = false;
    }

    public void StopTime()
    {
        TimerOn = false;
        //FillWant = TimeBar.fillAmount;
        //elapsedTime 
    }

    public void NextProject()
    {
        FillWant = 1;
        TimeBar.fillAmount = 0;
        elapsedTime = 0;
    }
}
