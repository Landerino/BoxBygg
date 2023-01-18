using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

//[RequireComponent(typeof(InputData))]
public class RemoteScript : MonoBehaviour
{
    public SceneInfo sceneInfo;
    [SerializeField] private InputActionReference RemoteReference;
    //[SerializeField] private float 
    //private InputData _inputData;

    public UITimeScript TimeScript;

    private void Start()
    {
        RemoteReference.action.performed += ChangeStateUI;
        //_inputData = GetComponent<InputData>();
    }

    void Update()
    {
        
        //if(_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out new int Pressure))
    }

    private void ChangeStateUI(InputAction.CallbackContext obj)
    {
        if (sceneInfo.HoldingRemote)
        {
            TimeScript.StartTime();
        }
    }
}
