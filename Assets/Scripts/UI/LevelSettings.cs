using System;
using TMPro;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreToWinText;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private int _minScore;
    [SerializeField] private int _maxScore;
    private int _scoreToWin = 7;

    public event Action SettingsChanged;

    private void Start()
    {
        _audio.volume = PlayerPrefs.GetFloat("Sound");
        _scoreToWinText.text = _scoreToWin.ToString();
    }

    public void AddGoalsToWin()
    {
        if (_scoreToWin < _maxScore)
        {
            _scoreToWin++;
        }

        _audio.Play();
        _scoreToWinText.text = _scoreToWin.ToString();
    }

    public void SubtractGoalsToWin()
    {
        if (_scoreToWin > _minScore)
        {
            _scoreToWin--;
        }

        _audio.Play();
        _scoreToWinText.text = _scoreToWin.ToString();
    }

    public void Submit()
    {
        _audio.Play();
        SettingsChanged?.Invoke();
        gameObject.SetActive(false);
    }

    public int GetScoreToWin()
    {
        return _scoreToWin;
    }
}