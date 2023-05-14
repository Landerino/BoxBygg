using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ClipboardScript : MonoBehaviour
{
    PhotonView PV;

    private bool IsOn1;
    private bool IsOn2;
    private bool IsOn3;

    public GameObject WaterPipes;
    public GameObject ElectricityCables;
    public GameObject AirVents;
    public GameObject Check1;
    public GameObject Check2;
    public GameObject Check3;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        IsOn1 = false;
        IsOn2 = false;
        IsOn3 = false;
        WaterPipes.SetActive(false);
        ElectricityCables.SetActive(false);
        AirVents.SetActive(false);
        Check1.SetActive(false);
    }

    public void Switch(int Check2)
    {
        string Number = Check2.ToString();
        PV.RPC("ShowHide" + Number, RpcTarget.All);
    }

    [PunRPC]
    void ShowHide1()
    {
        Debug.Log("in 1");
        if (!IsOn1)
        {
            IsOn1 = true;
            WaterPipes.SetActive(true);
            Check1.SetActive(true);
        }
        else
        {
            IsOn1 = false;
            WaterPipes.SetActive(false);
            Check1.SetActive(false);
        }
    }

    [PunRPC]
    void ShowHide2()
    {
        Debug.Log("in 2");
        if (!IsOn2)
        {
            IsOn2 = true;
            ElectricityCables.SetActive(true);
            Check2.SetActive(true);
        }
        else
        {
            IsOn2 = false;
            ElectricityCables.SetActive(false);
            Check2.SetActive(false);
        }
    }

    [PunRPC]
    void ShowHide3()
    {
        Debug.Log("in 3");
        if (!IsOn3)
        {
            IsOn3 = true;
            AirVents.SetActive(true);
            Check3.SetActive(true);
        }
        else
        {
            IsOn3 = false;
            AirVents.SetActive(false);
            Check3.SetActive(false);
        }
    }
}
