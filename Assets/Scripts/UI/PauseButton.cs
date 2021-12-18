using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private Button _pauseButton;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(ShowPausePanel);
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(ShowPausePanel);
        }

        private void ShowPausePanel()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}