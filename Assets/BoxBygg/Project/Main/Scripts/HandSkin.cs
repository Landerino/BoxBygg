using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSkin : MonoBehaviour
{
    public SceneInfo sceneInfo;

    public Color32[] skinColorArray;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_BaseColor", skinColorArray[sceneInfo.playerSkinNo]);
    }
    
    public void setSkinColor(int number)
    {
        sceneInfo.playerSkinNo = number;
        UpdateHandSkin();
    }

    private void UpdateHandSkin()
    {
        rend.material.SetColor("_BaseColor", skinColorArray[sceneInfo.playerSkinNo]);
    }

}
