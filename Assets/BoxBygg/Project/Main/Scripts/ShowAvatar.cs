using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAvatar : MonoBehaviour
{
    public GameObject[] Avatars;
    private int SelectedAvatar;
    private int OldAvatar;
    public Transform Here;

    void Start()
    {
        SelectedAvatar = 0;
        UpdateMyAvatar(SelectedAvatar);
    }

    public void changeAvatar(int avatarno)
    {
        HideAvatar(OldAvatar);
        UpdateMyAvatar(avatarno);
        SaveMYOldAvatar(avatarno);
    }

    private void SaveMYOldAvatar(int old)
    {
        OldAvatar = old;
    }

    public void HideAvatar(int old2)
    {
        Avatars[OldAvatar].SetActive(false);
    }

    private void UpdateMyAvatar(int SA)
    {
        Avatars[SA].gameObject.SetActive(true);
    }
}
