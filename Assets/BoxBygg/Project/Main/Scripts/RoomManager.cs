using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using System;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    public List<PlayerController> playerItemsList = new List<PlayerController>();
    public PlayerController playerItemPrefab;
    public Transform playerItemParent;



    //Only one manager allowed in a scene at a time
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1) // has to be multiplayer game scene 
        {

        }
    }
    void UpdatePlayerList()
    {
        foreach(PlayerController item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if(PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            Instantiate(playerItemPrefab, playerItemParent);
        }
        
    }
}
