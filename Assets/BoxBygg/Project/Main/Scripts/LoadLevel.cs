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

    public bool nameInputed;
    public bool AvatarSelected;

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

    private void Start()
    {
        nameInputed = false;
        AvatarSelected = false;
    }

    public void UpdateName()
    {
        nameInputed = true;
        StartChecker();
    }

    public void UpdateAvatar()
    {
        AvatarSelected = true;
        StartChecker();
    }

    void StartChecker()
    {
        if(nameInputed && AvatarSelected)
        {
            gameObject.SetActive(true);
        }
    }
}