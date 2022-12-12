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

    public Transform InstancePoint;

    public GameObject[] AvatarList;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

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
        if (PV.IsMine)
        {
            Debug.Log(PhotonNetwork.NickName);
            Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["avatar"]);
        }
    }
}
