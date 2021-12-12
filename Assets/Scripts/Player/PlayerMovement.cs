using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;
        private Touch _touch;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                Vector2 touchPosition = _camera.ScreenToWorldPoint(_touch.position);
                if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
                {
                    _rigidbody.MovePosition(Vector2.Lerp(_rigidbody.position, touchPosition, Time.fixedDeltaTime * _speed));
                }
            }
            
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _rigidbody.MovePosition(Vector2.Lerp(_rigidbody.position, mousePosition, Time.fixedDeltaTime * _speed));
            }
#endif
        }
    }
}