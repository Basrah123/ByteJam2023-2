using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject player;
    public float sensitivity = 2.0f;
    public float verticalRotationLimit = 80.0f;

    private Vector3 offset;
    private Rigidbody rb;

    private float currentRotationX = 0f;

    void Start()
    {
        offset = transform.position - player.transform.position;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze Rigidbody rotation to prevent unwanted physics interactions
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    void Update()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X") * sensitivity; // Get horizontal mouse input and apply sensitivity
        float rotateVertical = Input.GetAxis("Mouse Y") * sensitivity; // Get vertical mouse input and apply sensitivity

        // Rotate around the Y-axis (player's left/right)
        player.transform.Rotate(Vector3.up * rotateHorizontal);

        // Rotate around the X-axis (camera's up/down)
        currentRotationX -= rotateVertical;
        currentRotationX = Mathf.Clamp(currentRotationX, -verticalRotationLimit, verticalRotationLimit);

        // Apply the new rotation using Quaternion
        transform.localRotation = Quaternion.Euler(currentRotationX, 0f, 0f);
    }
}
