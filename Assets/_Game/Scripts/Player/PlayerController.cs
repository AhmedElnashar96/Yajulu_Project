using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables

    #region Exposed
    #endregion

    #region Hidden
    [SerializeField] private PlayerData playerData;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AnimationsManager animationsManager;

    private float horizontalInput;
    private float forwardSpeed;
    private float horizontalSpeed;
    private bool isFalling = false;
    #endregion

    #endregion

    private void Start()
    {
        IntializePlayer();
    }
    private void Update()
    {
        MovePlayer();
    }

    /// <summary>
    /// Intialize player's values
    /// </summary>
    private void IntializePlayer()
    {
        forwardSpeed = playerData.forwardSpeed;
        horizontalSpeed = playerData.horizontalSpeed;
    }


    /// <summary>
    /// Move Player Horizontally
    /// </summary>
    private void MovePlayer()
    {
        //Move Forward
        characterController.Move(transform.forward * horizontalSpeed * Time.deltaTime);

        //Move Horizontal
        Vector3 movement = transform.right * horizontalInput;
        characterController.SimpleMove(movement * horizontalSpeed);

        //Play Animation
        PlayMovementAnimation();
    }


    /// <summary>
    /// Update Horizontal Value with the value taken from input system
    /// </summary>
    public void onMove(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }


    /// <summary>
    /// Play Animation based on player current state
    /// </summary>
    private void PlayMovementAnimation()
    {
        if (isFalling)
        {
            animationsManager.ChangeAnimationState(Constants.FALL_ANIMATION);
        }
        else
        {
            animationsManager.ChangeAnimationState(Constants.IDLE_ANIMATION);
        }
    }

}
