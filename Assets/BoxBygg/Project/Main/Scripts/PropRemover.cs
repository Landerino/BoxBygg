using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PropRemover : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
             int RemovingItem = other.gameObject.GetComponent<PhotonView>().ViewID;
            PhotonNetwork.Destroy(PhotonView.Find(RemovingItem));
        }
    }
}