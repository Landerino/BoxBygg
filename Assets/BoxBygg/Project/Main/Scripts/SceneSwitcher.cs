using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using BNG;

public class SceneSwitcher : MonoBehaviour
{
    PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(2);
        PV.RPC("Initiate", RpcTarget.All);
        
    }

    public void SwitchScene2()
    {
        SceneManager.LoadScene(1);
        PV.RPC("Initiate2", RpcTarget.All);
        
    }

    [PunRPC]
    private void Initiate()
    {
        Photon.Pun.PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(2);
    }

    [PunRPC]
    private void Initiate2()
    {
        Photon.Pun.PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(1);
    }
}
