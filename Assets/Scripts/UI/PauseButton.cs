using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Button _button;
        
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
        _pausePanel.Open();
    }
}