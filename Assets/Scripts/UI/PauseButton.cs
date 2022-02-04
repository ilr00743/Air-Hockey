using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Button _button;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StartPause);
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