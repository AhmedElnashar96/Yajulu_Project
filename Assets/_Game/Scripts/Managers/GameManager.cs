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
            StartCoroutine(DelayBeforeRotation());
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
            StartCoroutine(DelayBeforeRotation());
        }
    }

    /// Event listener to turn game off when player dies
    public void TurnGameOff()
    {
        isGameOn = false;
    }

    IEnumerator DelayBeforeRotation()
    {
        plate.DOMoveX(thePlayer.position.x, 0f);

        for (int i = 1; i <= 180; i++)
        {
            if (isLeft)
            {
                plate.RotateAround(thePlayer.position, transform.forward, 1);
            }
            else
            {
                plate.RotateAround(thePlayer.position, transform.forward, -1);
            }

            yield return new WaitForEndOfFrame();
        }

        plate.DOMoveX(thePlayer.position.x, 0.2f);
    }
}
