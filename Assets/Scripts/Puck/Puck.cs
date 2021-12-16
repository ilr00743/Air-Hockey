using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Puck : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        LimitVelocity();
        LimitMovement();
    }

    private void LimitVelocity()
    {
        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }
    }

    private void LimitMovement()
    {
        _rigidbody.position = new Vector2(
            Mathf.Clamp(_rigidbody.position.x, -1.89f, 1.89f), 
            Mathf.Clamp(_rigidbody.position.y, -4.3f, 4.4f)
            );
    }

    public IEnumerator ResetPosition(float x, float y)
    {
        _rigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        _rigidbody.position = new Vector2(x, y);
    }

    public Vector2 GetPosition()
    {
        return _rigidbody.position;
    }
}
