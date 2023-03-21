using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayVideo : MonoBehaviour
{
    PhotonView Superview;

    private bool isOn;
    public GameObject Screen;
    public GameObject text;

    void Start()
    {
        Superview = GetComponent<PhotonView>();
        isOn = false;
        Screen.SetActive(false);
        text.SetActive(true);
    }

    public void TurnOnOff()
    {
        Superview.RPC("TurnOnOffRPC", RpcTarget.All);
    }

    [PunRPC]
    private void TurnOnOffRPC()
    {
        if (!isOn)
        {
            text.SetActive(false);
            Screen.SetActive(true);
            isOn = true;
        }
        else
        {
            Screen.SetActive(false);
            text.SetActive(true);
            isOn = false;
        }
    }

}
