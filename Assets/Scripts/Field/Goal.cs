using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Goal : MonoBehaviour
{
    [SerializeField] private Puck _puck; 
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private ParticleSystem _goalParticle;
    [SerializeField] private AudioSource _audio;
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
            UpdateScore();
            PlacePuck();
            _goalParticle.Play();
            _audio.Play();
            CheckGameEnd();
        }
    }

    private void CheckGameEnd()
    {
        if (_currentScore == _levelSettings.GetScoreToWin())
        {
            GameOver?.Invoke();
        }
    }

    private void PlacePuck()
    {
        StartCoroutine(_puck.TakePositionAfterGoal());
    }

    private void UpdateScore()
    {
        _scoreText.text = (++_currentScore).ToString();
    }
}