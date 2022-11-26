using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Variables

    #region Hidden
    [SerializeField] private PlayerData playerData;

    [Space(20)]
    [Header("Values")]
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider healthSlider;

    [Space(20)]
    [Header("References")]
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject gameUI;

    [Space(20)]
    [Header("Prefabs")]
    [SerializeField] private Transform startMenuPrefab;
    [SerializeField] private Transform gameoverPrefab;

    private int scoreAmount = 0;
    private Transform instantiatedStartMenu;
    private Transform instantiatedGameoverMenu;
    #endregion

    #endregion


    private void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = playerData.health;
            healthSlider.value = healthSlider.maxValue;
        }

        ShowStartMenuUI();
    }


    /// Make sure that Game UI is hidden and instantiate the start menu
    private void ShowStartMenuUI()
    {
        gameUI.SetActive(false);

        if (instantiatedStartMenu == null)
        {
            instantiatedStartMenu = Instantiate(startMenuPrefab, canvas);
            instantiatedStartMenu.GetComponent<StartMenu>().SetupMenu(ShowGameUI);
        }
    }

    /// Show Game UI and destroy the start menu
    private void ShowGameUI()
    {
        if (instantiatedStartMenu != null)
        {
            Destroy(instantiatedStartMenu.gameObject);
        }

        gameUI.SetActive(true);
        GameManager.isGameOn = true;
    }

    /// SHow Gameover UI with collected score
    public void ShowGameOverUI()
    {
        gameUI.SetActive(false);

        if (instantiatedGameoverMenu == null)
        {
            instantiatedGameoverMenu = Instantiate(gameoverPrefab, canvas);
            instantiatedGameoverMenu.GetComponent<GameoverMenu>().UpdateScore(scoreAmount);
        }
    }


    #region Event Listeners
    /// Update Distance UI Event Listener
    public void onDistanceUpdate(int amount)
    {
        if (distanceText != null)
        {
            distanceText.SetText(amount.ToString());
        }
    }

    /// Update Score UI Event Listener
    public void onScoreUpdate(int amount)
    {
        if (scoreText != null)
        {
            NumbersCounter.Instance.SetNewValue(scoreAmount, amount, 1f, 100, scoreText, "");
            scoreAmount = amount;
            //scoreText.SetText(amount.ToString());
        }
    }

    /// Update Health UI Event Listener
    public void onHealthUpdate(int amount)
    {
        if (healthSlider != null)
        {
            healthSlider.value = amount;
        }
    }
    #endregion
}
