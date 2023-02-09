using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class InsideLobbyCheck : MonoBehaviourPunCallbacks
{

    public override void OnJoinedLobby()
    {
        Debug.Log("Welcome");
    }
}
