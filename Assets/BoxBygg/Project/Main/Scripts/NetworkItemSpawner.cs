using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkItemSpawner : MonoBehaviour
{
    public Vector3 SpawnItemHere;
    public Quaternion rotation;

    public void SpawnItem(string Item)
    {
        PhotonNetwork.InstantiateSceneObject(Item, SpawnItemHere, rotation);
    }

}
