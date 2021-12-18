using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _pause;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _home;

    private void OnEnable()
    {
        _pause.onClick.AddListener(ShowPausePanel);
        _resume.onClick.AddListener(Resume);
        _home.onClick.AddListener(ReturnToMenu);
    }

    private void OnDisable()
    {
        _pause.onClick.RemoveListener(ShowPausePanel);
        _resume.onClick.RemoveListener(Resume);
        _home.onClick.RemoveListener(ReturnToMenu);
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Resume()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void ShowPausePanel()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
