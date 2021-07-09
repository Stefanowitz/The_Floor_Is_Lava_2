using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public CharacterController controller;
    
    //Setting the movement speed
    public float moveSpeed = 12f;

    public float gravity = -10f;

    public float jumpHight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 veloctiy;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Creates af Sphere around the Groundcheck to see if it is touching ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && veloctiy.y < 0)
        {
            veloctiy.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
    
        float z = Input.GetAxis("Vertical");

        // Making the Movement Local
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            veloctiy.y = Mathf.Sqrt(jumpHight * -2f * gravity);
        }

        veloctiy.y += gravity * Time.deltaTime;

        controller.Move(veloctiy * Time.deltaTime);
    }
}
