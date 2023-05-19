using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneSwitcher : MonoBehaviour
{
    PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    public void SwitchScene()
    {
        PV.RPC("Initiate", RpcTarget.All);
        SceneManager.LoadScene(2);
    }

    public void SwitchScene2()
    {
        PV.RPC("Initiate2", RpcTarget.All);
        SceneManager.LoadScene(1);
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
