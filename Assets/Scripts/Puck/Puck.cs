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
    }

    private void LimitVelocity()
    {
        _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
    }

    private float GetAttackSide()
    {
        float playerSide = -0.9f;
        float aiSide = 0.9f;

        return transform.position.y < 0 ? playerSide : aiSide;
    }

    public IEnumerator TakePositionAfterGoal()
    {
        transform.position = new Vector3(0, transform.position.y, -0.6f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        _rigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(true);
        transform.position = new Vector3(0, GetAttackSide(), 0);
    }

    public Vector2 GetPosition()
    {
        return _rigidbody.position;
    }
}