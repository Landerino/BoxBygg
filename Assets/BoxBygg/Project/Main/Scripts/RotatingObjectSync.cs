using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BNG;

public class RotatingObjectSync : MonoBehaviour
{
    PhotonView View;
    public GameObject terrain;
    private int ppL;

    private GameObject rightGrabber;
    private GameObject leftGrabber;
    private Grabber rGrabber;
    private Grabber lGrabber;

    private void Start()
    {
        rightGrabber = GameObject.FindWithTag("RightGrabber");
        leftGrabber = GameObject.FindWithTag("LeftGrabber");
        rGrabber = rightGrabber.GetComponent<Grabber>();
        lGrabber = leftGrabber.GetComponent<Grabber>();
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
            Drop();
            ppL = other.gameObject.GetComponent<PhotonView>().ViewID;
            Debug.Log(ppL);
            View.RPC("ConnectRPC", RpcTarget.All, ppL);
        }
    }

    private void Drop()
    {
        if(rGrabber.HeldGrabbable != null)
        {
            rGrabber.HeldGrabbable.DropItem(rGrabber);
        }
        
        if(lGrabber.HeldGrabbable != null)
        {
            lGrabber.HeldGrabbable.DropItem(lGrabber);
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
