using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ColorChange : MonoBehaviourPun
{
    /*
    public Material[] hairMaterials;
    public Material[] shirtMaterials;

    private int selectedHairIndex = 0;
    private int selectedShirtIndex = 0;

    private string HairColorKey = "HairColorIndex";
    private string ShirtColorKey = "ShirtColorIndex";

    private void Start()
    {
        selectedHairIndex = PlayerPrefs.GetInt(HairColorKey, 0);
        selectedShirtIndex = PlayerPrefs.GetInt(ShirtColorKey, 0);

        ChangeHairMaterial(hairMaterials[selectedHairIndex]);
        ChangeShirtMaterial(shirtMaterials[selectedShirtIndex]);
    }

    public void ChangeHairMaterial(Material newMaterial)
    {
        selectedHairIndex = System.Array.IndexOf(hairMaterials, newMaterial);

        GameObject[] hairObjects = GameObject.FindGameObjectsWithTag("Hair");
        foreach (GameObject hairObject in hairObjects)
        {
            Renderer renderer = hairObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }

        PlayerPrefs.SetInt(HairColorKey, selectedHairIndex);
    }

    public void ChangeShirtMaterial(Material newMaterial)
    {
        selectedShirtIndex = System.Array.IndexOf(shirtMaterials, newMaterial);

        GameObject[] shirtObjects = GameObject.FindGameObjectsWithTag("Shirt");
        foreach (GameObject shirtObject in shirtObjects)
        {
            Renderer renderer = shirtObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }

        PlayerPrefs.SetInt(ShirtColorKey, selectedShirtIndex);
    }
    */
    public Material[] hairMaterials;
    public Material[] shirtMaterials;

    private int selectedHairIndex = 0;
    private int selectedShirtIndex = 0;

    private string HairColorKey = "HairColorIndex";
    private string ShirtColorKey = "ShirtColorIndex";

    private new PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        selectedHairIndex = PlayerPrefs.GetInt(HairColorKey, 0);
        selectedShirtIndex = PlayerPrefs.GetInt(ShirtColorKey, 0);

        Debug.Log("Hair materials array size: " + hairMaterials.Length);

        ChangeHairMaterial(hairMaterials[selectedHairIndex]);
        ChangeShirtMaterial(shirtMaterials[selectedShirtIndex]);
    }

    public void ChangeHairMaterial(Material newMaterial)
    {
        if (hairMaterials == null) return; // Check if the array is null

        selectedHairIndex = System.Array.IndexOf(hairMaterials, newMaterial);

        GameObject[] hairObjects = GameObject.FindGameObjectsWithTag("Hair");
        foreach (GameObject hairObject in hairObjects)
        {
            Renderer renderer = hairObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }

        PlayerPrefs.SetInt(HairColorKey, selectedHairIndex);


        // Check if we are connected to Photon before sending an RPC message
        if (PhotonNetwork.IsConnected)
        {
            photonView.RPC("SyncHairColor", RpcTarget.Others, selectedHairIndex);
        }
    }

    public void ChangeShirtMaterial(Material newMaterial)
    {
        selectedShirtIndex = System.Array.IndexOf(shirtMaterials, newMaterial);

        GameObject[] shirtObjects = GameObject.FindGameObjectsWithTag("Shirt");
        foreach (GameObject shirtObject in shirtObjects)
        {
            Renderer renderer = shirtObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }

        PlayerPrefs.SetInt(ShirtColorKey, selectedShirtIndex);

        // Check if we are connected to Photon before sending an RPC message
        if (PhotonNetwork.IsConnected)
        {
            photonView.RPC("SyncShirtColor", RpcTarget.Others, selectedShirtIndex);
        }
    }

    [PunRPC]
    void SyncHairColor(int hairColorIndex)
    {
        selectedHairIndex = hairColorIndex;
        ChangeHairMaterial(hairMaterials[selectedHairIndex]);
    }

    [PunRPC]
    void SyncShirtColor(int shirtColorIndex)
    {
        selectedShirtIndex = shirtColorIndex;
        ChangeShirtMaterial(shirtMaterials[selectedShirtIndex]);
    }
}