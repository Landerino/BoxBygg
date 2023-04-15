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
    public GameObject butnStart;
    public GameObject butnStop;
    public GameObject LocationText;
    public Animator Anim;
    public Animator Anim2;

    private int Date;
    private float desiredDuration = 5f;
    private float elapsedTime;
    private float FillWant;
    private bool TimerOn;
    private int Quarter;
    private int TotalQuarters;
    private int TotalQuarters2;
    private int ElapsedQuarters;
    private int ElapsedQuarters2;

    //All values and components set to default entry value or correct component
    void Start()
    {
        Anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        view = GetComponent<PhotonView>();
        Quarter = 1 ;
        Date = 2025;
        TimerOn = false;
        FillWant = 1;
        TimeBar.fillAmount = 0;
        Ytext.text = Date.ToString();
        Ytext2.text = Date.ToString();
        TotalQuarters = 31;
        TotalQuarters2 = 26;
        ElapsedQuarters = 0;
        ElapsedQuarters2 = 0;
    }
    
    //TimerOn is a bool when set to true starts the date and quarter time also the time bar to show progression of each quarter. 
    //fillAmount for TimeBar is used to refresh the progression bar whenever it hits 1 (100% filled) adding 1 to the current quarter and nextquarter function is called to update the text shown, starting it again at 0, gradually making its way back up again until - 
    //until the date reaches 2032 in the 4th quarter, activating the join button
    void Update()
    {
        if(Date < 2026 && Quarter < 3)
        {
            LocationText.SetActive(true);
            Ytext.text = "";
            Qtext.text = "";
        }
        else
        {
            LocationText.SetActive(false);
        }
        if (TimerOn)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            TimeBar.fillAmount = Mathf.Lerp(0, FillWant, percentageComplete);
            if(Date == 2025 && Quarter == 3)
            {
                ElapsedQuarters2 = 0;
                Anim2.Play("Scene");
            }
            else if(Date == 2025 && Quarter < 3)
            {
                Anim2.Play("Empty");
            }
        }
        if (TimeBar.fillAmount == 1)
        {
            TimeBar.fillAmount = 0;
            elapsedTime = 0;
            ElapsedQuarters++;
            ElapsedQuarters2++;
            Quarter++;
            NextQuarter();
        }
        else if(Date == 2032 && Quarter == 4)
        {
            TimerOn = false;
            butnStart.SetActive(true);
            butnStop.SetActive(false);
        }
        
    }

    //The two following functions are not needed to be synced online because everyone sees the timebar the same with the same values
    //This functon itself sets the correct dates and calls upon the function update text to refresh the numbers seen
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
    //Here the values are made into a string from an int and refreshes the showing UI
    private void UpdateText()
    {
        if (Date > 2025 || Quarter > 2)
        {
            Qtext.text = ("Q" + Quarter.ToString());
            Ytext.text = Date.ToString();
            Ytext2.text = Date.ToString();
        }
    }
    
    //Called when startbutton is pressed by any user, Sending a call via rpc to all targets (users) 
    public void StartTime()
    {
        view.RPC("StartTimeRPC", RpcTarget.All);
    }

    //The function to answer the request recieved by all users. Answers with setting the Timer Bool to true (starting the time), if the date is invalid the function doesnt do anything
    [PunRPC]
    private void StartTimeRPC()
    {
        if (Date == 2032 && Quarter < 4 || Date < 2032)
        {
            TimerOn = true;
            Anim.Play("TerrainMeshAnim");
            Anim.speed = 1;
            Anim2.speed = 1;
            butnStart.SetActive(false);
            butnStop.SetActive(true);
        }
    }

    //Called when stopbutton is pressed by any user, Sending a call via rpc to all targets (users) 
    public void StopTime()
    {
        view.RPC("StopTimeRPC", RpcTarget.All);
        //FillWant = TimeBar.fillAmount;
        //elapsedTime 
    }

    //The function to answer the request recieved by all users. Answers by stopping the animator speed component on the 
    [PunRPC]
    private void StopTimeRPC() 
    {
        butnStart.SetActive(true);
        butnStop.SetActive(false);
        TimerOn = false;
        Anim.speed = 0;
        Anim2.speed = 0;
    }

    //Called when skip is pressed by any user, Sending a call via rpc to all targets (users) 
    public void SkipNext()
    {
        view.RPC("SkipNextRPC", RpcTarget.All);
    }

    //Recieved by all users. Ultimately skips to the next quarter adding the correct date and resseting the time bar to match a new quarters beginning. 
    [PunRPC]
    private void SkipNextRPC()
    {
        if (Date == 2032 && Quarter < 4 || Date < 2032)
        {
            if(Date == 2025 && Quarter > 2 || Date > 2025)
            {
                ElapsedQuarters2++;
                float PlayTime2 = (float)ElapsedQuarters2 / TotalQuarters2;
                Debug.Log(PlayTime2);
                Anim2.Play("Scene", 0, PlayTime2);
            }
            ElapsedQuarters++;
            float PlayTime = (float)ElapsedQuarters / TotalQuarters;
            Debug.Log(PlayTime);
            Anim.Play("TerrainMeshAnim", 0, PlayTime);
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

    //Called when switching project, Sending a call via rpc to all targets (users)
    public void ChangeDate()
    {
        view.RPC("ChangeDateRPC", RpcTarget.All);
    }

    //Recieved by all users, Changing the date and deactivating/activating the start animation button because no animation exists for tempelriddaren. Sends UpdateText function to sync the date with the new project
    [PunRPC]
    private void ChangeDateRPC()
    {
        if(screen.Placeint == 1)
        {
            Date = 2025;
            Quarter = 1;
            butnStart.SetActive(false);
            UpdateText();
        }
        else if(screen.Placeint == 2)
        {
            elapsedTime = 0;
            Date = 2024;
            Quarter = 1;
            butnStart.SetActive(true);
            UpdateText();
        }
    }

    public void SkipPrevious()
    {
        view.RPC("SkipPreviousRPC", RpcTarget.All);
    }

    //Function to skip to previous quarter with parameters to check if the time is within the date the project is built, refreshes dates.
    [PunRPC]
    private void SkipPreviousRPC()
    {
        if (Date == 2025 && Quarter > 1 || Date > 2025)
        {
            if (Date == 2025 && Quarter > 2 || Date > 2025)
            {
                ElapsedQuarters2--;
                float PlayTime2 = (float)ElapsedQuarters2 / TotalQuarters2;
                Anim2.Play("Scene", 0, PlayTime2);
            }
            ElapsedQuarters--;
            float PlayTime = (float)ElapsedQuarters / TotalQuarters;
            Debug.Log(PlayTime);
            Anim.Play("TerrainMeshAnim", 0, PlayTime);
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
            if (Date == 2032 && Quarter == 3)
            {
                view.RPC("StartTimeRPC", RpcTarget.All);
            }
        }
    }
}
