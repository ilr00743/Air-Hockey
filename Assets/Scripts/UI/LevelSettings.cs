using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelSettings : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreToWinText;
        [SerializeField] private int _minScore;
        [SerializeField] private int _maxScore;
        private int _scoreToWin;

        public event Action SettingsChanged;

        private void Start()
        {
            // _scoreToWin = PlayerPrefs.GetInt("Score", 7);
            _scoreToWin = 7;
            _scoreToWinText.text = _scoreToWin.ToString();
        }
        
        public void AddScoreToWin()
        {
            if (_scoreToWin < _maxScore)
            {
                _scoreToWin++;
            }

            _scoreToWinText.text = _scoreToWin.ToString();
        }

        public void SubtractScoreToWin()
        {
            if (_scoreToWin > _minScore)
            {
                _scoreToWin--;
            }
            
            _scoreToWinText.text = _scoreToWin.ToString();
        }

        public void Submit()
        {
            SettingsChanged?.Invoke();
            gameObject.SetActive(false);
        }
        
        public int GetScoreToWin()
        {
            return _scoreToWin;
        }
    }
}