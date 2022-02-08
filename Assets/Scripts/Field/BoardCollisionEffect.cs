using System;
using System.Collections;
using UnityEngine;

public class BoardCollisionEffect : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private AudioClip _audioClip;
    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(0.25f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent(out Puck puck))
        {
            _audio.PlayOneShot(_audioClip);
        }

        StartCoroutine(SwapColor());
    }

    private IEnumerator SwapColor()
    {
        _sprite.color = Color.Lerp(Color.white, _color, 1);
        yield return _delay;
        _sprite.color = Color.Lerp(_color, Color.white, 1);
    }
}