using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ClipboardScript : MonoBehaviour
{
    PhotonView PhotonV;

    private int Page;
    private int OnsOffs;

    private bool IsOn1;
    private bool IsOn2;
    private bool IsOn3;

    public GameObject WaterPipes;
    public GameObject ElectricityCables;
    public GameObject AirVents;
    public GameObject Check1;
    public GameObject Check2;
    public GameObject Check3;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Roof;

    public Material[] materials;

    private Renderer rend;

    void Start()
    {
        PhotonV = GetComponent<PhotonView>();
        Page = 0;
        IsOn1 = false;
        IsOn2 = false;
        IsOn3 = false;
        Page1.SetActive(true);
        Page2.SetActive(false);
        WaterPipes.SetActive(false);
        ElectricityCables.SetActive(false);
        AirVents.SetActive(false);
        Check1.SetActive(false);
        OnsOffs = 0;
        rend = Roof.GetComponent<Renderer>();
    }

    public void Switch1()
    {
        PhotonV.RPC("ShowHide1", RpcTarget.All);
    }
    public void Switch2()
    {
        PhotonV.RPC("ShowHide2", RpcTarget.All);
    }
    public void Switch3()
    {
        PhotonV.RPC("ShowHide3", RpcTarget.All);
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
            OnsOffs++;
        }
        else
        {
            IsOn1 = false;
            WaterPipes.SetActive(false);
            Check1.SetActive(false);
            OnsOffs--;
        }
        UpdateRenderSide();
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
            OnsOffs++;
        }
        else
        {
            IsOn2 = false;
            ElectricityCables.SetActive(false);
            Check2.SetActive(false);
            OnsOffs--;
        }
        UpdateRenderSide();
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
            OnsOffs++;
        }
        else
        {
            IsOn3 = false;
            AirVents.SetActive(false);
            Check3.SetActive(false);
            OnsOffs--;
        }
        UpdateRenderSide();
    }

    public void FlipPageF()
    {
        Page++;
        if (Page == 2)
        {
            Page = 0;
            ShowPage();
        }
        else ShowPage();
    }

    public void FlipPageB()
    {
        Page--;
        if (Page == -1)
        {
            Page = 1;
            ShowPage();
        }
        else ShowPage();
    }

    void UpdateRenderSide()
    {
        if(OnsOffs != 0)
        {
            rend.material = materials[1];
        }
        else
        {
            rend.material = materials[0];
        }
    }

    void ShowPage()
    {
        if(Page == 1)
        {
            Page2.SetActive(true);
            Page1.SetActive(false);
        }
        else
        {
            Page1.SetActive(true);
            Page2.SetActive(false);
        }
    }

}
