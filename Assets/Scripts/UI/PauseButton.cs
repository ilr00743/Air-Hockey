using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audio;

    private void OnEnable()
    {
        _button.onClick.AddListener(StartPause);
    }

    private void Start()
    {
        _audio.volume = PlayerPrefs.GetFloat("Sound");
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartPause);
    }

    private void StartPause()
    {
        _audio.Play();
        _pausePanel.Open();
    }
}