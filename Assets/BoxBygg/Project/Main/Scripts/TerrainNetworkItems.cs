using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BNG;

public class TerrainNetworkItems : MonoBehaviourPunCallbacks
{
    public GameObject Sign;
    public GameObject[] RoadInfos;
    public RotatingObjectSync Rts;

    //private int ObjectNumber; 
    
    [PunRPC]
    void ConnectRPC(int PID)
    {
        //ObjectNumber = PID;
        StartCoroutine(Delay(PID));
    }

    IEnumerator Delay(int PID)
    {
        yield return new WaitForSecondsRealtime(0.7f);
        RemoveGrabbable(PID);
    }

    void RemoveGrabbable(int PID)
    {
        PhotonView.Find(PID).gameObject.transform.SetParent(this.transform);
        Destroy(PhotonView.Find(PID).gameObject.GetComponent<NetworkedGrabbable>());
    }

    [PunRPC]
    void DisconnectRPC(int PID)
    {
        PhotonView.Find(PID).transform.SetParent(null);
        //PID.transform.SetParent(null);
    }

    public void EnableSign()
    {
        Sign.SetActive(true);
    }

    public void showRoadInfo(int num)
    {
        RoadInfos[num].gameObject.SetActive(true);
    }

    public void hideRoadInfo(int num)
    {
        RoadInfos[num].gameObject.SetActive(false);
    }
}
