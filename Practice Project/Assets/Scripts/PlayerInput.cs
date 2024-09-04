using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Checks for and receives player input

    // NEEDS:
    // A delegate
    // Method for each input check

    const float IGNORE = 0;

    #region Input Buttons
    public string walkButton = "Horizontal";
    public string jumpButton = "Jump";
    public string shootButton = "Fire1";
    #endregion

    float hInput;

    public delegate void PlayerInputDelegate(float axis);
    public event PlayerInputDelegate OnPlayerJump;
    public event PlayerInputDelegate OnPlayerWalk;
    public event PlayerInputDelegate OnPlayerShoot;

    private void Update()
    {
        // Get the current horizontal axis (left/right)
        if (hInput != Input.GetAxisRaw(walkButton)) 
        {
            hInput = Input.GetAxisRaw(walkButton);
        }

        BasicMovementCheck();
        AttackCheck();
    }

    #region Movement Checks
    void BasicMovementCheck() 
    {
        if (Input.GetButton(walkButton)) 
        {
            WalkInput();
        }

        if (Input.GetButtonDown(jumpButton)) 
        {
            JumpInput();
        }
    }

    void AttackCheck() 
    {
        if (Input.GetButtonDown(shootButton)) 
        { 
            ShootInput();
        }
    }

    void JumpInput()
    {
        OnPlayerJump?.Invoke(IGNORE);
    }

    void WalkInput()
    {
        OnPlayerWalk?.Invoke(hInput);
    }

    void ShootInput() 
    {
        OnPlayerShoot?.Invoke(IGNORE);
    }
    #endregion
}
