using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallRespawn : MonoBehaviour
{
    private Vector3 originalPosition;
    private Rigidbody rb;
    private int TouchCount;
    PhotonView Pview;

    void Start()
    {
        TouchCount = 0;
        Pview = GetComponent<PhotonView>();
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Pview.RPC("RecallBall", RpcTarget.All);
        }
    }

    [PunRPC]
    void RecallBall()
    {
        TouchCount++;
        if (TouchCount > 2)
        {
            transform.position = originalPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            TouchCount = 0;
        }
    }
}
