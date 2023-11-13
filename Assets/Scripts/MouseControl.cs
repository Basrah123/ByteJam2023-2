using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject player; 
    public float sensitivity; 

    private Vector3 offset;
    private Rigidbody rb;

    private void Start()
    {
        offset = transform.position - player.transform.position;
        rb = GetComponent<Rigidbody>(); 
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }

    private void FixedUpdate()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y"); 

        Vector3 rotation = new Vector3(rotateHorizontal, 0.0f, rotateVertical); 

        rb.AddForce(rotation * sensitivity); 
    }
}

