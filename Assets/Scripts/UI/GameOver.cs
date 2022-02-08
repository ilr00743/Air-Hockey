using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Goal[] _goals;
    [SerializeField] private Button _retry, _home;
    [SerializeField] private TMP_Text _winLose;

    private void OnEnable()
    {
        foreach (var goal in _goals)
        {
            goal.GameOver += OnGameOver;
        }

        _retry.onClick.AddListener(Retry);
        _home.onClick.AddListener(GoToMenu);
    }

    private void OnDisable()
    {
        foreach (var goal in _goals)
        {
            goal.GameOver -= OnGameOver;
        }

        _retry.onClick.RemoveListener(Retry);
        _home.onClick.RemoveListener(GoToMenu);
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

    private void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}