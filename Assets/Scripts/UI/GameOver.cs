using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{
    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Goal[] _goals;
    [SerializeField] private Button _retry, _home;
    [SerializeField] private TMP_Text _winLose;
    [SerializeField] private AudioSource _audio;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);

    private void OnEnable()
    {
        foreach (var goal in _goals)
        {
            goal.GameOver += OnGameOver;
        }

        _retry.onClick.AddListener(Retry);
        _home.onClick.AddListener(GoToMenu);
    }

    private void Start()
    {
        _audio.volume = PlayerPrefs.GetFloat("Sound");
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4602167", false);
        }
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
        _audio.Play();
        ShowAd();
        StartCoroutine(LoadSceneAfterSeconds(SceneManager.GetActiveScene().name));
        Time.timeScale = 1;
    }

    private void GoToMenu()
    {
        _audio.Play();
        ShowAd();
        StartCoroutine(LoadSceneAfterSeconds("MainMenu"));
        Time.timeScale = 1;
    }

    private void ShowAd()
    {
        Advertisement.Show("Interstitial_Android");
    }
    
    private IEnumerator LoadSceneAfterSeconds(string sceneName)
    {
        yield return _delay;
        SceneManager.LoadScene(sceneName);
    }
}