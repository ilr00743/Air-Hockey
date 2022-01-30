using System;
using System.Collections;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private Puck puck;
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
        _startPosition = new Vector2(0f, 4f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (IsPuckOnSide())
        {
            MoveToTarget();
        }
        if(!_canKick || !IsPuckOnSide())
        {
            TakeStartPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Puck puck))
        {
            StartCoroutine(CooldownAfterKick());
        }
    }

    private bool IsPuckOnSide()
    {
        return puck.GetPosition().y >= 0.1f && puck.GetPosition().y <= 4.32f;
    }

    private void TakeStartPosition()
    {
        _rigidbody.MovePosition(Vector2.MoveTowards(
            _rigidbody.position, _startPosition,
            Time.fixedDeltaTime * _speedMovement));
    }

    private void MoveToTarget()
    {
        _rigidbody.MovePosition(Vector2.Lerp(_rigidbody.position, puck.GetPosition(),
            _speedMovement * Time.fixedDeltaTime));
    }

    private IEnumerator CooldownAfterKick()
    {
        yield return new WaitForSeconds(0.07f);
        _canKick = false;
        yield return new WaitForSeconds(0.3f);
        _canKick = true;
    }
}