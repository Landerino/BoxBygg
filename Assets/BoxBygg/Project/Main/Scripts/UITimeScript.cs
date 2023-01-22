using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimeScript : MonoBehaviour
{

    public TextMeshProUGUI Ytext;
    public TextMeshProUGUI Qtext;
    public Image TimeBar;
    public GameObject butnJoin;

    private int Date;
    private float desiredDuration = 11f;
    private float elapsedTime;
    private float FillWant;
    private bool TimerOn;
    private int Quarter;

    void Start()
    {
        Quarter = 1;
        Date = 2024;
        TimerOn = false;
        FillWant = 1;
        TimeBar.fillAmount = 0;
        Ytext.text = Date.ToString();
    }


    void Update()
    {
        if (TimerOn)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            TimeBar.fillAmount = Mathf.Lerp(0, FillWant, percentageComplete);
            /*
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
            */
        }
        if (TimeBar.fillAmount == 1)
        {
            TimeBar.fillAmount = 0;
            elapsedTime = 0;
            Quarter++;
            NextQuarter();
            //butnJoin.SetActive(true);
        }
            //else butnJoin.SetActive(false);
    }

    public void NextQuarter()
    {
        if (Quarter == 5)
        {
            Date++;
            Quarter = 1;
            UpdateText();
        }
        else UpdateText();
        
    }
    private void UpdateText()
    {
        Qtext.text = ("Q" + Quarter.ToString());
        Ytext.text = Date.ToString();
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
    //                                                                          ---------Fix skip pre-2024 and after 2032------------------
    public void SkipNext()
    {
        if (Quarter == 4)
        {
            Date++;
            Quarter = 1;
            UpdateText();
        }
        else
        {
            Quarter++;
            TimeBar.fillAmount = 0;
            elapsedTime = 0;
            UpdateText();
        }
    }
    public void SkipPrevious()
    {
        if (Quarter == 1)
        {
            Date--;
            Quarter = 4;
            UpdateText();
        }
        else
        {
            Quarter--;
            TimeBar.fillAmount = 0;
            elapsedTime = 0;
            UpdateText();
        }
    }
}
