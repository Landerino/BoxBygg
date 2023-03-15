using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SyncScenes : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        int numPlayers = PhotonNetwork.CountOfPlayers;
        Debug.Log("players: " + numPlayers);
        //PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New player Joined");
        //PhotonNetwork.Instantiate(playerPrefab2.name, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
