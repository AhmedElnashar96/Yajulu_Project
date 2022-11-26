using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

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
    private bool shouldRotate = false;
    private float rotAngle = 0;
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
        if (!isGameOn)
        {
            return;
        }

        if (!isLeft)
        {

            isLeft = true;

            plate.position = new Vector3(thePlayer.position.x, plate.position.y, plate.position.z);
            StartCoroutine(DelayBeforeRotation(false));
            //plate.RotateAround(thePlayer.position, transform.forward, 180);
        }
       
    }

    /// Rotate the world to the right
    public void RotateWorldRight()
    {
        if (!isGameOn)
        {
            return;
        }

        if (isLeft)
        {
            isLeft = false;

            plate.position = new Vector3(thePlayer.position.x, plate.position.y, plate.position.z);
            StartCoroutine(DelayBeforeRotation(true));
            //plate.RotateAround(thePlayer.position, transform.forward, -180);
        }
    }

    /// Event listener to turn game off when player dies
    public void TurnGameOff()
    {
        isGameOn = false;
    }

    IEnumerator DelayBeforeRotation(bool isNegative)
    {
        for (int i = 1; i <= 30; i++)
        {
            if (isNegative)
            {
                plate.RotateAround(thePlayer.position, transform.forward, -6);
            }
            else
            {
                plate.RotateAround(thePlayer.position, transform.forward, 6);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
