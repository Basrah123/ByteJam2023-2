using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSway : MonoBehaviour
{
    
    public float smooth;
    public float swayAmount;
 
    // Update is called once per frame
    void Update()
    {
       float mouseX = -Input.GetAxisRaw("Mouse X") * swayAmount;
       float mouseY = Input.GetAxisRaw("Mouse Y") * swayAmount;
 
       Quaternion rotationX = Quaternion.AngleAxis(mouseY, Vector3.right);
       Quaternion rotationY = Quaternion.AngleAxis(-mouseX, Vector3.up);
 
       Quaternion targetRotation = rotationX * rotationY;
 
       transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
