using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace ErfanDeveloper
{
    public enum GameState
    {
        Starting,
        InGame,
        EndGame
    }

    public class OnGUIManager : MonoBehaviour
    {
        #region Singelton
        public static OnGUIManager instance;
        private void Awake()
        {
            if (instance != null)
                return;
            instance = this;
        }
        #endregion
        [Header("Ui Refrense")]
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private Text scoreInGameText;
        [SerializeField] private Text currentScoreInEndPanelText;
        [SerializeField] private Text bestScoreInEndPanelText;
        [SerializeField] private GameObject endGamePanel;

        private GameObject currentPanel;

        public void UpdateUiState(GameState state)
        {
            if (currentPanel != null)
                currentPanel.SetActive(false);
            switch (state)
            {
                case GameState.Starting:
                    currentPanel = startPanel;
                    break;
                case GameState.InGame:
                    currentPanel = inGamePanel;
                    break;
                case GameState.EndGame:
                    currentPanel = endGamePanel;
                    break;
            }
            currentPanel.SetActive(true);
        }
        public void UpdateScoreInGameText(float score)
        {
            scoreInGameText.text = score.ToString("0");
        }
        public void CheckAndSaveBestScore(float currentScore)
        {
            currentScoreInEndPanelText.text = currentScore.ToString("0");
            float bestScore = SaveAndLoadSytem.Load("BestScore");
            if (currentScore > bestScore)
                SaveAndLoadSytem.Save("BestScore", currentScore);
            bestScoreInEndPanelText.text = SaveAndLoadSytem.Load("BestScore").ToString("0");
        }
        #region BtnsFounction
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        #endregion
    }
}
