using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelOptionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreToWinText;
        [SerializeField] private int _minScore;
        [SerializeField] private int _maxScore;
        private int _scoreToWin;

        private void Start()
        {
            _scoreToWin = PlayerPrefs.GetInt("Score", 7);
            _scoreToWinText.text = _scoreToWin.ToString();
        }
        public void AddScoreToWin()
        {
            if (_scoreToWin < _maxScore)
            {
                _scoreToWin++;
            }

            _scoreToWinText.text = _scoreToWin.ToString();
            PlayerPrefs.SetInt("Score", _scoreToWin);
        }

        public void SubtractScoreToWin()
        {
            if (_scoreToWin > _minScore)
            {
                _scoreToWin--;
            }
            
            _scoreToWinText.text = _scoreToWin.ToString();
            PlayerPrefs.SetInt("Score", _scoreToWin);
        }

        public int GetScoreToWin()
        {
            return _scoreToWin;
        }
    }
}