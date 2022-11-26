using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    #region Variables

    #region Exposed
    [HideInInspector] public bool isFalling = false;
    #endregion

    #region Hidden
    [SerializeField] private PlayerData playerData;

    [Space(15)]
    [Header("Settings")]
    [SerializeField] private AnimationsManager animationsManager;
    [SerializeField] private Rigidbody theRigidbody;
    [SerializeField] private PlayerHealthController healthController;

    private float horizontalInput;
    private float forwardSpeed;
    private float horizontalSpeed;
    private float FallingThreshold = -7f;  
    
    #endregion

    #endregion

    private void Start()
    {
        IntializePlayer();
    }
    private void Update()
    {
        if (!GameManager.isGameOn)
        {
            return;
        }

        if (theRigidbody.velocity.y < FallingThreshold)
        {
            isFalling = true;
            animationsManager.ChangeAnimationState(Constants.FALL_ANIMATION);
        }
        else
        {
            isFalling = false;
            MovePlayer();
        }

        if (theRigidbody.velocity.y < -50f)
        {
            isFalling = true;
            healthController.DamageThePlayer(0.1f);
        }

    }


    /// Intialize player's values
    private void IntializePlayer()
    {
        forwardSpeed = playerData.forwardSpeed;
        horizontalSpeed = playerData.horizontalSpeed;
    }

    /// Move Player Horizontally And Play Movement Animation
    private void MovePlayer()
    {
        theRigidbody.velocity = new Vector3(horizontalInput * horizontalSpeed, theRigidbody.velocity.y, forwardSpeed);
        PlayMovementAnimation();
    }

    /// Update Horizontal Value with the value taken from input system
    public void onMove(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    /// Play Animation based on player current state
    private void PlayMovementAnimation()
    {
        if (healthController.isHurt)
        {
            return;
        }

        animationsManager.ChangeAnimationState(Constants.IDLE_ANIMATION);
    }

}
