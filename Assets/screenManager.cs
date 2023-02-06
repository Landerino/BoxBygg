using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class screenManager : MonoBehaviour
{
    PhotonView Pview;

    public TextMeshProUGUI PlaceText;
    public GameObject Storobj;
    public GameObject Riddarobj;

    private int Placeint;
    
    void Start()
    {
        Pview = GetComponent<PhotonView>();
        Placeint = 1;
        PlaceText.text = ("Storängen");
    }

    public void SwitchTerrain()
    {
        Pview.RPC("SwitchTerrainRPC", RpcTarget.All);
    }

    [PunRPC]
    private void SwitchTerrainRPC()
    {
        if(Placeint == 1)
        {
            Storobj.SetActive(false);
            Riddarobj.SetActive(true);
            Placeint = 2;
            PlaceText.text = ("Storängen");
        }
        else if(Placeint == 2)
        {
            Riddarobj.SetActive(false);
            Storobj.SetActive(true);
            Placeint = 1; 
            PlaceText.text = ("Tempelriddaren");
        }
    }

}
