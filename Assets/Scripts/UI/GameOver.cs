using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GoalTrigger[] _goals = new GoalTrigger[2];
        [SerializeField] private Button _retry, _home;
        private void OnEnable()
        {
            foreach (var goal in _goals)
            {
                goal.GameOver += OnGameOver;
            }
        }

        private void OnDisable()
        {
            foreach (var goal in _goals)
            {
                goal.GameOver -= OnGameOver;
            }
        }
        
        private void Start()
        {
            _retry.onClick.AddListener(Retry);
            _home.onClick.AddListener(Home);
        }

        private void OnGameOver()
        {
            EnablePanel();
            Time.timeScale = 0;
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