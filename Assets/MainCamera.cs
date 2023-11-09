using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
        m_CameraTwo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // L button to switch cameras
        if (Input.GetKeyDown(KevCode.L))
        {
            if (m_MainCamera.enabled)
           {
             m_CameraTwo.enabled = true;

             m_MainCamera.enabled = false;
           }
           else if (!m_MainCamera.enabled)
           {
            m_CameraTwo.enabled = false;

            m_MainCamera.enabled = true;
           }
        }
    }
}