using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Calculates and outputs the player's jump and walk.

    // NEEDS:
    // Reference to player object
    // Reference to PlayerInput script
    // Method for jumping and walking
    // jump height and walk speed variables

    public float jumpHeight = 3f;
    public float walkSpeed = 1f;

    Rigidbody playerRB;

    PlayerInput playerInput;

    void Start()
    {
        // Assign components
        playerRB = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        // Subscribe methods to delegates
        playerInput.OnPlayerJump += Jump;
        playerInput.OnPlayerWalk += Walk;
    }

    void Jump(float ignore)
    {
        try
        {
            playerRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    void Walk(float axis) 
    {
        try
        {
            //playerRB.AddForce(Vector3.right * walkSpeed * axis - playerRB.velocity, ForceMode.Force);
            transform.position += Vector3.right * walkSpeed * axis * Time.deltaTime;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
