using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIMovement : MonoBehaviour
{
    [SerializeField] private Puck _puck;
    [SerializeField] private float _speedMovement;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition;
    private bool _canKick;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _canKick = true;
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
            MoveToTarget();
        }
        if(!_canKick)
        {
            TakeStartPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Puck puck))
        {
            StartCoroutine(OnCooldownAfterKick());
        }
    }

    private bool IsPuckOnSide()
    {
        return _puck.GetPosition().y >= 0.2f && _puck.GetPosition().y <= 3.88f;
    }

    private void TakeStartPosition()
    {
        _rigidbody.MovePosition(Vector2.MoveTowards(
            _rigidbody.position, _startPosition,
            Time.fixedDeltaTime * _speedMovement));
    }

    private void MoveToTarget()
    {
        _rigidbody.MovePosition(Vector2.MoveTowards(_rigidbody.position, _puck.GetPosition(),
            _speedMovement * Time.fixedDeltaTime));
    }

    private IEnumerator OnCooldownAfterKick()
    {
        yield return new WaitForSeconds(0.07f);
        _canKick = false;
        yield return new WaitForSeconds(0.3f);
        _canKick = true;
    }
}