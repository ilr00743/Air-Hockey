using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Puck : MonoBehaviour
{
    [SerializeField] private float _maxVelocity;
    private Rigidbody2D _rigidbody;
    // private Vector2 _lastVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        LimitVelocity();
        // LimitMovement();
    }

    private void LimitVelocity()
    {
        if (_rigidbody.velocity.magnitude > _maxVelocity)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = _lastVelocity.magnitude;
        var direction = Vector2.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);

        _rigidbody.velocity = direction * Mathf.Max(speed, 0f);
    }*/

    public IEnumerator ResetPosition(float x, float y)
    {
        yield return new WaitForSeconds(0.05f);
        _rigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        _rigidbody.position = new Vector2(x, y);
    }

    public Vector2 GetPosition()
    {
        return _rigidbody.position;
    }
}
