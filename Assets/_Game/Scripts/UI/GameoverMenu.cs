using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameoverMenu : MonoBehaviour
{
    #region Variables

    #region Exposed
    #endregion

    #region Hidden
    [SerializeField] private TextMeshProUGUI scoreAmountText;
    [SerializeField] private Button restartButton;
    #endregion

    #endregion
   

    private void Start()
    {
        restartButton.onClick.AddListener(ReloadScene);
    }
    public void UpdateScore(int score)
    {
        //scoreAmountText.SetText(score.ToString());
        NumbersCounter.Instance.SetNewValue(0, score, 1f, 100, scoreAmountText, "");
        restartButton.transform.DOScale(new Vector3(1, 1, 1), 1);
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE_NAME);
    }
}
