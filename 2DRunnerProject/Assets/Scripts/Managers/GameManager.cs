using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class GameManager : MonoBehaviour
    {
        #region Singelton
        public static GameManager instace;
        private void Awake()
        {
            if (instace != null)
                return;
            instace = this;
        }
        #endregion

        [HideInInspector] public bool canPlayGame;
        [HideInInspector] public bool isGameOver;

        private float currentScore;
        private bool isGameStarted;
        private void Start()
        {
            First_Refrenses();
        }
        private void First_Refrenses()
        {
            OnGUIManager.instance.UpdateUiState(GameState.Starting);
            isGameStarted = false;
            isGameOver = false;
        }
        private void Update()
        {
            CheckCanStartGame();
            canPlayGame = isGameStarted && !isGameOver ? true : false;
            if (canPlayGame)
            {
                currentScore += Time.deltaTime;
                OnGUIManager.instance.UpdateScoreInGameText(currentScore);
            }
        }
        public void Die()
        {
            OnGUIManager.instance.CheckAndSaveBestScore(currentScore);
        }
        private void CheckCanStartGame()
        {
            if (isGameStarted)
                return;
            if (Input.GetMouseButtonDown(0))
            {
                isGameStarted = true;
                OnGUIManager.instance.UpdateUiState(GameState.InGame);
                AudioManager.instance.StartGame();
            }
        }
    }
}
