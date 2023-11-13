using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement_speed;
    private CharacterController myController;
    public float Gravity = 9.8f;
    private float velocity = 0f;

    private void Start()
    {
        myController= GetComponent<CharacterController>();
    }
    private void Update()
    {
        MoveMe();
    }

    private void MoveMe()
    {
        float horizontal = Input.GetAxis("Horizontal") * movement_speed;
        float vertical = Input.GetAxis("Vertical") * movement_speed;
        myController.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);

        // Gravity
        if (myController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            myController.Move(new Vector3(0, velocity, 0));
        }
    }
}
