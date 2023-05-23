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
        //PhotonNetwork.InstantiateRoomObject(Item, SpawnItemHere, rotation);     use this instead?
        PhotonNetwork.InstantiateSceneObject(Item, SpawnItemHere, rotation);
    }

}
