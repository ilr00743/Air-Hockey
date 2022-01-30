using System;
using UnityEngine;

public class BoardCollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void OnCollisionEnter2D(Collision2D col)
    {
        _particle.Play();
    }
}