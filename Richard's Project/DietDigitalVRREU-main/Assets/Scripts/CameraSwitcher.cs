using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public KeyCode switchKey = KeyCode.V; // Set to 'V' key.

    private void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // If first person camera is currently enabled, disable it and enable the third person camera.
        if (firstPersonCamera.enabled)
        {
            firstPersonCamera.enabled = false;
            thirdPersonCamera.enabled = true;
        }
        // If third person camera is currently enabled, disable it and enable the first person camera.
        else if (thirdPersonCamera.enabled)
        {
            thirdPersonCamera.enabled = false;
            firstPersonCamera.enabled = true;
        }
    }
}
