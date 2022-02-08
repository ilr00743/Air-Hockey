using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _home;
    [SerializeField] private AudioSource _audio;

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
        _audio.Play();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    private void Close()
    {
        _audio.Play();
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Open()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}