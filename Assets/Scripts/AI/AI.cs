using System.Collections;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AI : MonoBehaviour, IMoveable
{
    [SerializeField] private Puck _puck;
    [SerializeField] private float _speedMovement;
    [SerializeField] private AudioSource _audio;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition = new Vector2(0f, 4f);
    private bool _canKick;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _audio.volume = PlayerPrefs.GetFloat("Sound");
        _canKick = true;
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

        if (!_canKick || !IsPuckOnSide())
        {
            TakeStartPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Puck puck))
        {
            _audio.Play();
            StartCoroutine(CooldownAfterKick());
        }
    }

    private bool IsPuckOnSide()
    {
        return _puck.GetPosition().y >= 0.1f && _puck.GetPosition().y <= 4.32f;
    }

    private void TakeStartPosition()
    {
        _rigidbody.MovePosition(Vector2.MoveTowards(
            _rigidbody.position, _startPosition,
            Time.fixedDeltaTime * _speedMovement));
    }

    private void MoveToTarget()
    {
        _rigidbody.MovePosition(Vector2.Lerp(_rigidbody.position, _puck.GetPosition(),
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