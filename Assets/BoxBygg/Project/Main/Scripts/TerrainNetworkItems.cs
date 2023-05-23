using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BNG;

public class TerrainNetworkItems : MonoBehaviourPunCallbacks
{
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
        yield return new WaitForSecondsRealtime(0.9f);
        RemoveGrabbable(PID);
    }

    void RemoveGrabbable(int PID)
    {
        Destroy(PhotonView.Find(PID).gameObject.GetComponent<NetworkedGrabbable>());
        PhotonView.Find(PID).gameObject.transform.SetParent(this.transform);
    }

    [PunRPC]
    void DisconnectRPC(int PID)
    {
        PhotonView.Find(PID).transform.SetParent(null);
    }
}
