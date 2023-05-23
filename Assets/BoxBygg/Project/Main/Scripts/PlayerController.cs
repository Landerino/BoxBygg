using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView PV;
    public Text PlayerName;
    private string Numba;
    private int AvatarNo;
    private string ShirtColor;
    private int ShirtNo;
    private string HairColor;
    private int HairNo;

    //where to instantiate the avatar
    public Transform InstancePoint;

    //list of both hands to set color
    public GameObject[] Hands;

    //arrays with the avatars and colors
    public GameObject[] AvatarList;
    public Material[] CorrespondingAvatarColor;

    Renderer rend;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    //as soon as a player connects this runs and displays the player as intended
    private void Start()
    {
        Numba = PV.Owner.CustomProperties["avatar"].ToString();
        AvatarNo = int.Parse(Numba);
        GameObject Avatar = Instantiate(AvatarList[AvatarNo], InstancePoint);
        PlayerName.text = PV.Owner.NickName;
        ShirtColor = PV.Owner.CustomProperties["color"].ToString();
        ShirtNo = int.Parse(ShirtColor);
        HairColor = PV.Owner.CustomProperties["hair"].ToString();
        HairNo = int.Parse(HairColor);
        Avatar.GetComponent<ShirtChanger>().ShirtColor = ShirtNo;
        Avatar.GetComponent<ShirtChanger>().Updatecolor();
        Avatar.GetComponent<ShirtChanger>().HairColor = HairNo;
        Avatar.GetComponent<ShirtChanger>().UpdateHair();
        for(int i = 0; i < 2; i++)
        {
            rend = Hands[i].GetComponent<Renderer>();
            rend.material = CorrespondingAvatarColor[AvatarNo];
        }
        
        //Just checking if all is correct when loading :)
        if (PV.IsMine)
        {
            Debug.Log(PhotonNetwork.NickName);
            Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["avatar"]);
            Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["hair"]);
        }
    }
}
