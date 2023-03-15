using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class screenManager : MonoBehaviour
{
    PhotonView Pview;

    public UITimeScript timeScript;
    
    public TextMeshProUGUI PlaceText;
    public GameObject Storobj;
    public GameObject Riddarobj;
    public GameObject Nextbtn;
    public GameObject Previousbtn;

    public int Placeint;
    
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
        timeScript.StopTime();
        timeScript.TimeBar.fillAmount = 0;
        if (Placeint == 1)
        {
            timeScript.ChangeDate();
            Storobj.SetActive(false);
            Riddarobj.SetActive(true);
            Placeint = 2;
            PlaceText.text = ("Tempelriddaren");
            Nextbtn.SetActive(false);
            Previousbtn.SetActive(false);
        }
        else if(Placeint == 2)
        {
            timeScript.ChangeDate();
            Riddarobj.SetActive(false);
            Storobj.SetActive(true);
            Placeint = 1; 
            PlaceText.text = ("Storängen");
            Nextbtn.SetActive(true);
            Previousbtn.SetActive(true);
        }
    }

}
