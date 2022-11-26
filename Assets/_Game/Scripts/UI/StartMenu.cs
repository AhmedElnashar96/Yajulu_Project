using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartMenu : MonoBehaviour
{
    #region Variables

    #region Exposed
    #endregion

    #region Hidden
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    #endregion

    #endregion

    private void Start()
    {
        exitButton.onClick.AddListener(() => ExitGame());
    }
    public void SetupMenu(Action buttonFunction)
    {
        startButton.onClick.AddListener(() => buttonFunction());

        startButton.transform.DOScale(new Vector3(1,1,1), 1);
        exitButton.transform.DOScale(new Vector3(1,1,1), 1);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
