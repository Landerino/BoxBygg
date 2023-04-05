using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class UseShift : MonoBehaviour
{

    public VRKeyboard Key;
    private int Res;
    bool Once;

    public UnityEngine.UI.InputField Input;

    // Start is called before the first frame update
    void Start()
    {
        Once = true;
        //Time.fixedDeltaTime = 0.2f;
        Key.ToggleShift();
    }

    public void SetLower()
    {
        Key.ToggleShift();
    }

    private void FixedUpdate()
    {
        Res = Input.text.Length;
        if (Res > 0 && Once)
        {
            Key.ToggleShift();
            Once = false;
        }
        else if (Res == 0 && Once == false)
        {
            Key.ToggleShift();
            Once = true;
        }
        
    }
    
}
