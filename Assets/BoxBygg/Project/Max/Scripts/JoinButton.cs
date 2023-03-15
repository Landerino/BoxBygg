using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JoinButton : MonoBehaviour
{

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void LoadScene()
    {
            
        PhotonNetwork.LoadLevel(2);
    }

}
