using UnityEngine;

public class BoardCollisionEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent(out Puck puck))
        {
            Debug.Log("puck");
        }
    }
}
