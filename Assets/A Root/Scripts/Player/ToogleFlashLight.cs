using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleFlashLight : MonoBehaviour
{
    public GameObject lightGO; // Light GameObject to work with (the flashlight itself)
    public Transform cameraTransform; // Reference to the camera's Transform

    private bool isOn = false; // Is flashlight on or off?

    // Use this for initialization
    void Start()
    {
        // Set flashlight default to off
        lightGO.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle flashlight on key down (X key)
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Toggle light on/off
            isOn = !isOn;
            lightGO.SetActive(isOn); // Set the light active or inactive
        }

        // If the flashlight is on, make it follow the camera's rotation
        if (isOn)
        {
            // Update the flashlight's rotation to match the camera's rotation
            lightGO.transform.rotation = cameraTransform.rotation;
        }
    }

}
