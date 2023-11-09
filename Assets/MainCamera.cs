using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        CameraTwo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // L button to switch cameras
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (mainCamera.enabled)
           {
                 CameraTwo.enabled = true;
                 mainCamera.enabled = false;
           }
           else if (!mainCamera.enabled)
           {
                CameraTwo.enabled = false;
                mainCamera.enabled = true;
           }
        }
    }
}
