using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _home;

    private void OnEnable()
    {
        _resume.onClick.AddListener(Close);
        _home.onClick.AddListener(ReturnToMenu);
    }

    private void OnDisable()
    {
        _resume.onClick.RemoveListener(Close);
        _home.onClick.RemoveListener(ReturnToMenu);
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    private void Close()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Open()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}