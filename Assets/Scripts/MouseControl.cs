using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject player; 
    public float sensitivity = 2f; 

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        float rotateHorizontal = Input.GetAxis("Mouse X") * sensitivity;
        float rotateVertical = Input.GetAxis("Mouse Y") * sensitivity;

        player.transform.Rotate(Vector3.up, rotateHorizontal, Space.World);
        player.transform.Rotate(Vector3.left, rotateVertical, Space.Self);
    }
}
