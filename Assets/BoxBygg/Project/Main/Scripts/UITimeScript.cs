using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UITimeScript : MonoBehaviour
{
    PhotonView view;
    public TextMeshProUGUI Ytext;
    public TextMeshProUGUI Qtext;
    public Image TimeBar;
    public GameObject butnJoin;
    public GameObject butnStart;
    public GameObject butnStop;
    public Animator Anim;

    private int Date;
    private float desiredDuration = 10f;
    private float elapsedTime;
    private float FillWant;
    private bool TimerOn;
    private int Quarter;

    void Start()
    {
        view = GetComponent<PhotonView>();
        butnJoin.SetActive(false);
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
        else if(Date == 2032 && Quarter == 4)
        {
            TimerOn = false;
            butnStart.SetActive(true);
            butnStop.SetActive(false);
            butnJoin.SetActive(true);
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
        
        view.RPC("StartTimeRPC", RpcTarget.All);
    }

    [PunRPC]
    private void StartTimeRPC()
    {
        if (Date == 2032 && Quarter < 4 || Date < 2032)
        {
            TimerOn = true;
            Anim.Play("TerrainMeshAnim");
            Time.timeScale = 1;
        }
    }
    public void StopTime()
    {
        view.RPC("StopTimeRPC", RpcTarget.All);
        //FillWant = TimeBar.fillAmount;
        //elapsedTime 
    }

    [PunRPC]
    private void StopTimeRPC() 
    { 
        TimerOn = false;
        Time.timeScale = 0;
    }

    public void SkipNext()
    {
        view.RPC("SkipNextRPC", RpcTarget.All);
    }

    [PunRPC]
    private void SkipNextRPC()
    {
        if (Date == 2032 && Quarter < 4 || Date < 2032)
        {
            if (Quarter == 4)
            {
                Date++;
                Quarter = 1; 
                TimeBar.fillAmount = 0;
                elapsedTime = 0;
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
    }

    public void SkipPrevious()
    {
        view.RPC("SkipPreviousRPC", RpcTarget.All);
    }

    [PunRPC]
    private void SkipPreviousRPC()
    {
        butnJoin.SetActive(false);
        if (Date == 2024 && Quarter > 1|| Date > 2024)
        {
            if (Quarter == 1)
            {
                Date--;
                Quarter = 4; 
                TimeBar.fillAmount = 0;
                elapsedTime = 0;
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
}
