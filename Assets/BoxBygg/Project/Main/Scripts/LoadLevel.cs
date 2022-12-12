using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadLevel : MonoBehaviour
{
    public Text Name;
    

    ExitGames.Client.Photon.Hashtable playerAvatar = new ExitGames.Client.Photon.Hashtable();

    public void LoadMPLobby()
    {
        PhotonNetwork.NickName = Name.text;
        SceneManager.LoadScene(1);
    }

    public void SetAvatar(int Avatar)
    {
        playerAvatar["avatar"] = Avatar;
        PhotonNetwork.SetPlayerCustomProperties(playerAvatar);
    }

}
