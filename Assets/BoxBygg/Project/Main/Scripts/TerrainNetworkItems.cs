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
    void ConnectRPC(int ppL)
    {
        //ObjectNumber = ppL;
        StartCoroutine(Delay(ppL));
    }

    IEnumerator Delay(int ppL)
    {
        yield return new WaitForSecondsRealtime(0.7f);
        RemoveGrabbable(ppL);
    }

    void RemoveGrabbable(int ppL)
    {
        PhotonView.Find(ppL).gameObject.transform.SetParent(this.transform);
        Destroy(PhotonView.Find(ppL).gameObject.GetComponent<NetworkedGrabbable>());
    }

    [PunRPC]
    void DisconnectRPC(int ppL)
    {
        PhotonView.Find(ppL).transform.SetParent(null);
        //ppL.transform.SetParent(null);
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
