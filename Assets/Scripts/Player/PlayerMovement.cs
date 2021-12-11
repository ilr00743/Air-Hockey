using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Camera _camera;
        private Touch _touch;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                _rigidbody.MovePosition(mousePos);
            }
#endif
            Move();
        }

        private void Move()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                Vector2 touchPosition = _camera.ScreenToWorldPoint(_touch.position);
                if (_touch.phase == TouchPhase.Moved)
                {
                    _rigidbody.MovePosition(touchPosition);
                }
            }
        }
    }
}