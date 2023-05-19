using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotatingObjectSync : MonoBehaviour
{
    PhotonView View;
    public GameObject terrain;
    private int ppL;

    private void Start()
    {
        View = terrain.GetComponent<PhotonView>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("RemotePlayer"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Item"))
        {
            ppL = other.gameObject.GetComponent<PhotonView>().ViewID;
            Debug.Log(ppL);
            View.RPC("ConnectRPC", RpcTarget.All, ppL);
        }
    }

    /* Deprecated usage because new erazor object
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            ppL = other.gameObject.GetComponent<PhotonView>().ViewID;
            Debug.Log(ppL);
            View.RPC("DisconnectRPC", RpcTarget.All, ppL);
        }
    }
    */
}
