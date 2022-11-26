using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Variables

    #region Exposed
    public static bool isGameOn;
    #endregion

    #region Hidden
    [SerializeField] private Transform plate;
    [SerializeField] private Transform thePlayer;
    private GameControls controls;
    private bool isLeft = false;
    #endregion

    #endregion

    private void OnEnable()
    {
        controls.Game.Enable();
    }
    private void OnDisable()
    {
        controls.Game.Disable();
    }
    private void Awake()
    {
        controls = new GameControls();

        controls.Game.RotateWorldLeft.performed += context => RotateWorldLeft();
        controls.Game.RotateWorldRight.performed += context => RotateWorldRight();
    }


    /// Rotate the world to the left
    public void RotateWorldLeft()
    {
        if (!isLeft)
        {
            isLeft = true;

            plate.position = new Vector3(thePlayer.position.x, plate.position.y, plate.position.z);
            plate.RotateAround(thePlayer.position, transform.forward, 180);
        }
       
    }

    /// Rotate the world to the right
    public void RotateWorldRight()
    {
        if (isLeft)
        {
            isLeft = false;

            plate.position = new Vector3(thePlayer.position.x, plate.position.y, plate.position.z);
            plate.RotateAround(thePlayer.position, transform.forward, -180);
        }
    }

    /// Event listener to turn game off when player dies
    public void TurnGameOff()
    {
        isGameOn = false;
    }
}
