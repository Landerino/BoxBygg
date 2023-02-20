using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotatingObjectSync : MonoBehaviour
{
    PhotonView View;
    public GameObject terrain;
    public Collision ppL;

    private void Start()
    {
        View = terrain.GetComponent<PhotonView>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            ppL = other;
            View.RPC("ConnectRPC", RpcTarget.All);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (ppL.gameObject.CompareTag("Item"))
        {
            ppL = other;
            View.RPC("DisconnectRPC", RpcTarget.All);
        }
    }
}
