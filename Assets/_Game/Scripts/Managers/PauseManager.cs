using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    #region Variables

    #region Exposed
    [HideInInspector] public static bool isGamePaused = false;
    #endregion

    #region Hidden
    [SerializeField] private Transform gameCanvas;

    [SerializeField] private GameObject pauseMenu; //Prefab
    [SerializeField] private GameObject gameoverMenu; //Prefab

    private GameObject instansiatedMenu;
    private GameObject instansiatedGameOver;
    #endregion

    #endregion

    
    private void PauseGameWithPanel()
    {
        DestroyOldPanel();

        instansiatedMenu = Instantiate(pauseMenu, gameCanvas.position, Quaternion.identity, gameCanvas);
        isGamePaused = true;
    }
    private void ResumeGame()
    {
        DestroyOldPanel();

        isGamePaused = false;
    }
    private void DestroyOldPanel()
    {
        if (instansiatedMenu != null)
        {
            Destroy(instansiatedMenu);
        }
    }


    /// Pause game if it's not paused, and Unpause game if it's paused
    public void HandlePause()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGameWithPanel();
        }
    }

    /// Show Gameover screen
    public void GameOver()
    {
        instansiatedGameOver = Instantiate(gameoverMenu, gameCanvas.position, Quaternion.identity, gameCanvas);
        isGamePaused = true;
    }

    /// Destroy Gameover panel and restart the game
    public void RestartGame()
    {
        if (instansiatedGameOver != null)
        {
            Destroy(instansiatedGameOver);
        }

        isGamePaused = false;
    }
}
