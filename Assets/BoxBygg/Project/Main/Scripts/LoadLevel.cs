using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadLevel : MonoBehaviour
{
    public Text Name;

    public void LoadMPLobby()
    {
        PhotonNetwork.NickName = Name.text;
        SceneManager.LoadScene(1);
    }

}
