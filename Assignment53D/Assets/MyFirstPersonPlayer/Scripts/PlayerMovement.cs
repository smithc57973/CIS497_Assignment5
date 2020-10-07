/*
 * Chris Smith
 * Assignment53D
 * Controls player movement 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference to character controller
    public CharacterController controller;
    //Player move speed
    public float speed = 12f;
    //Gravity
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;
    //Ground Check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    //Player jump height
    public float jumpHeight = 3f;

    private void Awake()
    {
        //Reset gravity based on multiplier
        gravity *= gravityMultiplier;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Checking if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Reset gravity upon landing
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Get movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Create movement vector
        Vector3 move = transform.right * x + transform.forward * z;
        //Apply move
        controller.Move(move * speed * Time.deltaTime);
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
