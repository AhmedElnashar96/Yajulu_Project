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
    #endregion

    #endregion


    public void SetupMenu(Action buttonFunction)
    {
        startButton.onClick.AddListener(() => buttonFunction());
        startButton.transform.DOScale(new Vector3(1,1,1), 1);
    }
}
