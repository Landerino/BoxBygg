using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TerrainNetworkItems : MonoBehaviour
{
    public RotatingObjectSync Rts;

    [PunRPC]
    void ConnectRPC()
    {
        Rts.ppL.gameObject.transform.SetParent(this.transform);
    }

    [PunRPC]
    void DisconnectRPC()
    {
        Rts.ppL.gameObject.transform.SetParent(null);
    }
}
