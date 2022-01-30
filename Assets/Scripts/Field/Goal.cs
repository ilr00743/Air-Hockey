using System;
using TMPro;
using UI;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private Puck _puck;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private ParticleSystem _goalParticle;
    
    private int _currentScore;
    
    public int CurrentScore => _currentScore;
    
    public event Action GameOver;
    
    private void Start()
    {
        _currentScore = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Puck puck))
        {
            _scoreText.text = (++_currentScore).ToString();
            StartCoroutine(_puck.SetPositionAfterGoal());
            _goalParticle.Play();

            if (_currentScore == _levelSettings.GetScoreToWin())
            {
                GameOver?.Invoke();
            }
        }
    }
}