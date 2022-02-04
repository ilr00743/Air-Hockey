using UnityEngine;

public class BoardCollisionEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioSource _audio;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent(out Puck puck))
        {
            _audio.Play();
        }
    }
}
