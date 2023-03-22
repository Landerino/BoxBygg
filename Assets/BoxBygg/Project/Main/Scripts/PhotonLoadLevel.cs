using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PhotonLoadLevel : MonoBehaviourPunCallbacks
{
    


    public void LoadMPLobby()
    {
        PhotonNetwork.LoadLevel(1);
    }

}
