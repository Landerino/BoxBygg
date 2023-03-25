using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RotateTerrain : MonoBehaviour
{
    PhotonView View;

    public GameObject terrain;
    float Rotationint;
    bool spin;
    public Quaternion current;

    private void Start()
    {
        spin = false;
        Rotationint = -267.598f;
        View = GetComponent<PhotonView>();
    }

    public void TurnClockWise()
    {
        View.RPC("TurnClockWiseRPC", RpcTarget.All);
    }

    [PunRPC]
    void TurnClockWiseRPC()
    {
        Rotationint += 90;
        //Quaternion current = terrain.transform.rotation;
        spin = true;
        //terrain.transform.rotation = Quaternion.Euler(-90, 0, Rotationint);
    }

    public void TurnAntiClockwise()
    {
        View.RPC("TurnAntiClockWiseRPC", RpcTarget.All);
    }

    [PunRPC]
    void TurnAntiClockWiseRPC()
    {
        Rotationint -= 90;
        //Quaternion current = terrain.transform.rotation;
        spin = true;
        //terrain.transform.rotation = Quaternion.Euler(-90, 0, Rotationint);
    }

    private void Update()
    {
        Quaternion current = terrain.transform.rotation;
        if (spin)
        {
            terrain.transform.rotation = Quaternion.Slerp(current, Quaternion.Euler(-90, 0, Rotationint), 5f * Time.deltaTime);
        }
    }
}
