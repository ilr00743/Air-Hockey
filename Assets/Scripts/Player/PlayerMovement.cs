using System;
using UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

    private void Move()
    {
        if (_canMove)
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                Vector2 touchPosition = _camera.ScreenToWorldPoint(_touch.position);
                Vector2 clampedTouchPosition = new Vector2(
                    touchPosition.x, 
                    Mathf.Clamp(touchPosition.y,-3.5f, -0.1f)
                );
                if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Began)
                {
                    _rigidbody.MovePosition(
                        Vector2.MoveTowards(_rigidbody.position, clampedTouchPosition, 
                            Time.fixedDeltaTime * _speed));
                }
            }
        }
        
            
#if UNITY_EDITOR
        if (_canMove)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 clampedMousePosition = new Vector2(
                    mousePosition.x, Mathf.Clamp(mousePosition.y, -3.5f, -0.1f));
            
                _rigidbody.MovePosition(
                    Vector2.MoveTowards(_rigidbody.position, clampedMousePosition, 
                        Time.fixedDeltaTime * _speed));   
            }
        }
#endif
    }

    private void OnSettingsChanged()
    {
        _canMove = true;
    }
}