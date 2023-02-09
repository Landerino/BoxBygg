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

    //where to instantiate the avatar
    public Transform InstancePoint;

    /*
    //Grab hands to set color
    public GameObject HandLeft;
    public GameObject HandRight;
    */

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
        if(PV.Owner.CustomProperties["avatar"] == null)
        {
            AvatarNo = 0;
        }
        Numba = PV.Owner.CustomProperties["avatar"].ToString();
        AvatarNo = int.Parse(Numba);
        Instantiate(AvatarList[AvatarNo], InstancePoint);
        PlayerName.text = PV.Owner.NickName;
        for(int i = 0; i < 2; i++)
        {
            rend = Hands[i].GetComponent<Renderer>();
            rend.material = CorrespondingAvatarColor[AvatarNo];

        }
        /*
        rend = HandLeft.GetComponent<Renderer>();
        rend.sharedMaterial = CorrespondingAvatarColor[AvatarNo];
        rend = HandRight.GetComponent<Renderer>();
        rend.sharedMaterial = CorrespondingAvatarColor[AvatarNo];
        */
        if (PV.IsMine)
        {
            Debug.Log(PhotonNetwork.NickName);
            Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["avatar"]);
        }
    }
}
