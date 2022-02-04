using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _play, _settings;
    private AudioSource _audio;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);

    private void OnEnable()
    {
        _play.onClick.AddListener(StartGame);
        _settings.onClick.AddListener(OpenSettings);
    }

    private void OnDisable()
    {
        _play.onClick.RemoveListener(StartGame);
        _settings.onClick.RemoveListener(OpenSettings);
    }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void StartGame()
    {
        _audio.Play();
        StartCoroutine(LoadSceneAfterSeconds("Level"));
    }

    private void OpenSettings()
    {
        _audio.Play();
        StartCoroutine(LoadSceneAfterSeconds("Settings"));
    }

    private IEnumerator LoadSceneAfterSeconds(string sceneName)
    {
        yield return _delay;
        SceneManager.LoadScene(sceneName);
    }
}
