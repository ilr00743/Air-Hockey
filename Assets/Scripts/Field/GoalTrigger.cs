using System;
using TMPro;
using UI;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private Puck _puck;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private LevelSettings _levelSettings;
    private int _currentScore;

    public event Action GameOver;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Puck puck))
        {
            if (_currentScore + 1 == _levelSettings.GetScoreToWin())
            {
                GameOver?.Invoke();
            }
            
            _currentScore++;
            _scoreText.text = _currentScore.ToString();
            StartCoroutine(_puck.ResetPosition(0, SetAttackSide()));
        }
    }

    private float SetAttackSide()
    {
        float playerSide = -0.9f;
        float aiSide = 0.9f;
        return transform.position.y < 0f ? playerSide : aiSide;
    }
}
