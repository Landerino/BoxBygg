using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JoinButton : MonoBehaviour
{

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel(2);
    }

}
