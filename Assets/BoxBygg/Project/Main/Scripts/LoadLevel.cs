using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadLevel : MonoBehaviour
{
    public Text Name;
    public ShowAvatar SA;
    
    ExitGames.Client.Photon.Hashtable playerAvatar = new ExitGames.Client.Photon.Hashtable();
    ExitGames.Client.Photon.Hashtable shirtColor = new ExitGames.Client.Photon.Hashtable();

    public bool nameInputed;
    public bool AvatarSelected;
    public bool ShirtSelected;
    private bool Ready;

    public Color NewNormalColor;
    public Color NewHighlightedColor;
    public Color NewPressedColor;

    public void LoadMPLobby()
    {
        if (Ready)
        {
            PhotonNetwork.NickName = Name.text;
            SceneManager.LoadScene(1);
        }
    }

    public void SetAvatar(int Avatar)
    {
        playerAvatar["avatar"] = Avatar;
        PhotonNetwork.SetPlayerCustomProperties(playerAvatar);
    }

    public void SetShirtColor(int ShirtColor)
    {
        shirtColor["color"] = ShirtColor;
        PhotonNetwork.SetPlayerCustomProperties(shirtColor);

    }

    private void Start()
    {
        SetAvatar(0);
        SetShirtColor(5);
        nameInputed = false;
        AvatarSelected = false;
        Ready = false;
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
        if(nameInputed)
        {
            Ready = true;
            Button StartBTN = GetComponent<Button>();
            ColorBlock colors = StartBTN.colors;
            colors.normalColor = NewNormalColor;
            colors.highlightedColor = NewHighlightedColor;
            colors.pressedColor = NewPressedColor;
            StartBTN.colors = colors;
        }
    }
}