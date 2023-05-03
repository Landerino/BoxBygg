using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneSwitcher : MonoBehaviour
{
    PhotonView PV;
    private int scene;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    public void SwitchScene(int numberOfScene)
    {
        scene = numberOfScene;
        PV.RPC("Initiate", RpcTarget.All);
    }
    [PunRPC]
    private void Initiate()
    {
        Photon.Pun.PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(scene);
    }
}
