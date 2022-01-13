using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private LevelSettings _levelSettings;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GoalTrigger[] _goals;
        [SerializeField] private Button _retry, _home;
        [SerializeField] private TMP_Text _winLose;
        private void OnEnable()
        {
            _goals[0].GameOver += OnGameOver;
            _goals[1].GameOver += OnGameOver;
            _retry.onClick.AddListener(Retry);
            _home.onClick.AddListener(Home);
        }

        private void OnDisable()
        {
            _goals[0].GameOver -= OnGameOver;
            _goals[1].GameOver -= OnGameOver;
            _retry.onClick.RemoveListener(Retry);
            _home.onClick.RemoveListener(Home);
        }

        private void OnGameOver()
        {
            EnablePanel();
            ChooseWinner();
            Time.timeScale = 0;
        }

        private void ChooseWinner()
        {
            _winLose.SetText(_goals[0].CurrentScore == _levelSettings.GetScoreToWin() ? "You Win!" : "You Lose!");
        }

        private void EnablePanel()
        {
            _gameOverPanel.SetActive(true);
        }

        private void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }

        private void Home()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }
    }
}