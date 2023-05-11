using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

public class ColorChange : MonoBehaviourPunCallbacks
{
    public Material[] hairMaterials;
    public Material[] shirtMaterials;

    private int selectedHairIndex = 0;
    private int selectedShirtIndex = 0;

    private string HairColorKey = "HairColorIndex";
    private string ShirtColorKey = "ShirtColorIndex";

    private void Start()
    {
        // Load the saved color preferences
        selectedHairIndex = PlayerPrefs.GetInt(HairColorKey, 0);
        selectedShirtIndex = PlayerPrefs.GetInt(ShirtColorKey, 0);

        // Apply the saved color preferences to the avatar
        ChangeHairMaterial(hairMaterials[selectedHairIndex]);
        ChangeShirtMaterial(shirtMaterials[selectedShirtIndex]);
    }

    public void ChangeHairMaterial(Material newMaterial)
    {
        try
        {
            if (hairMaterials == null) return; // Check if the array is null

            selectedHairIndex = System.Array.IndexOf(hairMaterials, newMaterial);

            // Set the selected hair color index in the PhotonPlayer.CustomProperties
            ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable();
            props[HairColorKey] = selectedHairIndex;
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);

            GameObject[] hairObjects = GameObject.FindGameObjectsWithTag("Hair");
            foreach (GameObject hairObject in hairObjects)
            {
                Renderer renderer = hairObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = newMaterial;
                }
            }

            // Call an RPC to sync the hair color change with other clients
            photonView.RPC("SyncHairColor", RpcTarget.Others, selectedHairIndex);
        }
        catch (System.Exception e)
        {
            Debug.Log("Error changing hair material: " + e.Message);
        }
    }

    public void ChangeShirtMaterial(Material newMaterial)
    {
        try
        {
            selectedShirtIndex = System.Array.IndexOf(shirtMaterials, newMaterial);

            ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable();
            props[HairColorKey] = selectedHairIndex;
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);

            GameObject[] shirtObjects = GameObject.FindGameObjectsWithTag("Shirt");
            foreach (GameObject shirtObject in shirtObjects)
            {
                Renderer renderer = shirtObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = newMaterial;
                }
            }

            // Call an RPC to sync the shirt color change with other clients
            photonView.RPC("SyncShirtColor", RpcTarget.Others, selectedShirtIndex);
        }
        catch (System.Exception e)
        {
            Debug.Log("Error changing hair material: " + e.Message);
        }
    }

    [PunRPC]
    private void SyncHairColor(int newColorIndex)
    {
        ChangeHairMaterial(hairMaterials[newColorIndex]);
    }

    [PunRPC]
    private void SyncShirtColor(int newColorIndex)
    {
        ChangeShirtMaterial(shirtMaterials[newColorIndex]);
    }
}