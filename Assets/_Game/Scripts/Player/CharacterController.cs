using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    #region Variables

    #region Exposed
    #endregion

    #region Hidden
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Rigidbody rigidBody;

    private float horizontalInput;
    private float speed;
    #endregion

    #endregion



    private void Start()
    {
        IntializePlayer();
    }
    private void Update()
    {
        ControlPlayer();
    }

    private void IntializePlayer()
    {
        speed = playerData.speed;
    }

    /// <summary>
    /// Move Player Horizontally
    /// </summary>
    private void ControlPlayer()
    {
        rigidBody.velocity = new Vector3(horizontalInput * speed, rigidBody.velocity.y, rigidBody.velocity.z);
    }
    /// <summary>
    /// Update Horizontal Value with the value taken from input system
    /// </summary>
    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }
}
