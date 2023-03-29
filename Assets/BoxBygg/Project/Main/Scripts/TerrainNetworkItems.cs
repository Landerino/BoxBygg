using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TerrainNetworkItems : MonoBehaviour
{
    public GameObject Sign;
    public GameObject[] RoadInfos;
    public RotatingObjectSync Rts;

    [PunRPC]
    void ConnectRPC(int ppL)
    {
        PhotonView.Find(ppL).transform.SetParent(this.transform);
        Destroy(PhotonView.Find(ppL).gameObject.GetComponent<PhotonView>());
        //ppL.transform.SetParent(this.transform);
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
