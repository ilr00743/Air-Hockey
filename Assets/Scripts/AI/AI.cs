using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AI : MonoBehaviour
{
    [SerializeField] private Puck _puck;
    [SerializeField] private float _speedMovement;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = new Vector2(0f, 2.9f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (IsPuckOnSide())
        {
            ChaseTarget();
        }
        else
        {
            TakeStartPosition();
        }
    }

    private bool IsPuckOnSide()
    {
        return _puck.GetPosition().y >= 0.3f && _puck.GetPosition().y <= 3.8f;
    }

    private void TakeStartPosition()
    {
        _rigidbody.MovePosition(Vector2.MoveTowards(
            _rigidbody.position, _startPosition,
            Time.fixedDeltaTime * _speedMovement));
    }

    private void ChaseTarget()
    {
        _rigidbody.MovePosition(Vector2.MoveTowards(_rigidbody.position, _puck.GetPosition(),
            _speedMovement * Time.fixedDeltaTime));
    }
}