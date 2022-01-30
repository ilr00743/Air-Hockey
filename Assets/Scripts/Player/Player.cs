﻿using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private LevelSettings _settings;
    private Rigidbody2D _rigidbody;
    private Touch _touch;
    private bool _canMove;

    private void OnEnable()
    {
        _settings.SettingsChanged += OnSettingsChanged;
    }

    private void OnDisable()
    {
        _settings.SettingsChanged -= OnSettingsChanged;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _canMove = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (_canMove && Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            Vector2 touchPosition = _camera.ScreenToWorldPoint(_touch.position);

            if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
            {
                _rigidbody.MovePosition(Vector2.Lerp(_rigidbody.position, touchPosition, 
                    Time.fixedDeltaTime * _speed));
            }
        }
        
            
#if UNITY_EDITOR
        if (_canMove && Input.GetMouseButton(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            _rigidbody.MovePosition(
                Vector2.Lerp(_rigidbody.position, mousePosition, 
                    Time.fixedDeltaTime * _speed));
        }
#endif
    }

    private void OnSettingsChanged()
    {
        _canMove = true;
    }
}