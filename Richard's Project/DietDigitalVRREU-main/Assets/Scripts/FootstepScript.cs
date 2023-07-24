using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep;
    List<InputDevice> devices;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(true);
        devices = new List<InputDevice>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, devices);
        foreach(var device in devices)
        {
            Vector2 input;
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out input) && input != Vector2.zero)
            {
                footsteps();
            }
            else
            {
                StopFootsteps();
            }
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
}
