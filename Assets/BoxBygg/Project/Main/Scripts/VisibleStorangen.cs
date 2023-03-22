using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class VisibleStorangen : MonoBehaviour
{
    PhotonView PView;
    public CanvasCaller CCaller;

    public GameObject Storangen;
    public GameObject Room;

    private void Start()
    {
        PView = GetComponent<PhotonView>();
    }
    public void ShowHideStorangen()
    {
        PView.RPC("ShowHideStorangenRPC", RpcTarget.All);
    }

    [PunRPC]
    public void ShowHideStorangenRPC()
    {
        if (!CCaller.IsShowing)
        {
            Storangen.SetActive(true);
            Room.SetActive(false);
            CCaller.IsShowing = true;
            CCaller.ShowHideCanvas();
        }
        else
        {
            Storangen.SetActive(false);
            Room.SetActive(true);
            CCaller.IsShowing = false;
            CCaller.ShowHideCanvas();
        }
    }
}
