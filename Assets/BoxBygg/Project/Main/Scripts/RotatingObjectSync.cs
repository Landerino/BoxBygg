using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BNG;

public class RotatingObjectSync : MonoBehaviour
{
    PhotonView View;
    public GameObject terrain;
    private int PID;

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

    //when an item touches the terrain the id saves and later sets the terrain as a parent
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Drop();
            PID = other.gameObject.GetComponent<PhotonView>().ViewID;
            View.RPC("ConnectRPC", RpcTarget.All, PID);
        }
    }

    //Drops the held item from the users hands
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
            PID = other.gameObject.GetComponent<PhotonView>().ViewID;
            Debug.Log(PID);
            View.RPC("DisconnectRPC", RpcTarget.All, PID);
        }
    }
    */
}
