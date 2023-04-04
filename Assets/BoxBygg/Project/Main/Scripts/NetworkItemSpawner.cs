using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkItemSpawner : MonoBehaviour
{
    public GameObject ItemToSpawn;

    public Vector3 SpawnItemHere;
    public Quaternion rotation;

    public void SpawnItem()
    {
        Debug.Log("Spawned");
        PhotonNetwork.InstantiateSceneObject("Shed", SpawnItemHere, rotation);
    }

}
