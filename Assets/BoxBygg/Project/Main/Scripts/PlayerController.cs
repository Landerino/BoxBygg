using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PhotonView PV;
    public Text PlayerName;

    int skinIndex;
    int previousSkinIndex = -1;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        PlayerName.text = PV.Owner.NickName;

        if (PV.IsMine)
        {
            Debug.Log("Yo");
        }
    }


}
