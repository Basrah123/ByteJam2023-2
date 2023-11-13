 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField] private float movement_speed;
    private CharacterController myController;
    public float Gravity = 9.8f;
    private float velocity = 0f;
    private void Start()
    {
        myController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        MoveMe();
    }

    private void MoveMe()
    {
        float horizontal = Input.GetAxis("Horizontal") * movement_speed;
        float vertical = Input.GetAxis("Vertical") * movement_speed;

        // Get the player's forward and right vectors based on rotation
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Remove the y component to keep the movement in the horizontal plane
        forward.y = 0f;
        right.y = 0f;

        // Normalize vectors to ensure consistent speed in all directions
        forward.Normalize();
        right.Normalize();

        // Calculate the movement direction based on player input and rotation
        Vector3 moveDirection = forward * vertical + right * horizontal;

        myController.Move(moveDirection * Time.deltaTime);

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
