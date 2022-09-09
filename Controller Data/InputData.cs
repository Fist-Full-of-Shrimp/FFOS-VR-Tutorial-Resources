using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputData : MonoBehaviour
{
    public InputDevice _rightController;
    public InputDevice _leftController;
    public InputDevice _HMD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void InitializeInputDevices()
    {
        
        if(!_rightController.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref _rightController);
        if (!_leftController.isValid) 
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref _leftController);
        if (!_HMD.isValid) 
            InitializeInputDevice(InputDeviceCharacteristics.HeadMounted, ref _HMD);

    }

    private void InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();
        //Call InputDevices to see if it can find any devices with the characteristics we're looking for
        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        //Our hands might not be active and so they will not be generated from the search.
        //We check if any devices are found here to avoid errors.
        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!_rightController.isValid || !_rightController.isValid || !_HMD.isValid)
            InitializeInputDevices();
    }
}