using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UITimeScript : MonoBehaviour
{
    public screenManager screen;

    PhotonView view;
    public TextMeshProUGUI Ytext;
    public TextMeshProUGUI Ytext2;
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
        Anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        view = GetComponent<PhotonView>();
        butnJoin.SetActive(false);
        Quarter = 1;
        Date = 2024;
        TimerOn = false;
        FillWant = 1;
        TimeBar.fillAmount = 0;
        Ytext.text = Date.ToString();
        Ytext2.text = Date.ToString();
    }
    
    void Update()
    {
        if (TimerOn)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            TimeBar.fillAmount = Mathf.Lerp(0, FillWant, percentageComplete);
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
        Ytext2.text = Date.ToString();
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
            Anim.speed = 1;
            butnStart.SetActive(false);
            butnStop.SetActive(true);
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
        butnStart.SetActive(true);
        butnStop.SetActive(false);
        TimerOn = false;
        Anim.speed = 0;
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

    public void ChangeDate()
    {
        view.RPC("ChangeDateRPC", RpcTarget.All);
    }

    [PunRPC]
    private void ChangeDateRPC()
    {
        if(screen.Placeint == 1)
        {
            Date = 2019;
            butnStart.SetActive(false);
            Quarter = 1;
            UpdateText();
        }
        else if(screen.Placeint == 2)
        {
            Date = 2024;
            Quarter = 1;
            UpdateText();
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
