using System.Collections;
using UnityEngine;

namespace Puck
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PuckMovement : MonoBehaviour
    {
        [SerializeField] private float _maxVelocity;
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
            if (_rigidbody.velocity.magnitude > _maxVelocity)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
            }
        }

        private float GetAttackSide()
        {
            float playerSide = -0.9f;
            float aiSide = 0.9f;
        
            return _rigidbody.position.y < 0 ? playerSide : aiSide;
        }
    
        public IEnumerator SetPositionAfterGoal()
        { 
            gameObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);
        
            _rigidbody.velocity = Vector2.zero;
            yield return new WaitForSeconds(0.5f);
        
            gameObject.SetActive(true);
            _rigidbody.position = new Vector2(0, GetAttackSide());
        }

        public Vector2 GetPosition()
        {
            return _rigidbody.position;
        }
    }
}