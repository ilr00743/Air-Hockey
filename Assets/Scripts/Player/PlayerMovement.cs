using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

#if UNITY_EDITOR
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Debug.Log("Editor");
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _rigidbody.MovePosition(mousePos);
            }
        }
#endif
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Touch touch)
        {
            _rigidbody.position = new Vector2();
            _rigidbody.MovePosition(_rigidbody.position);
        }
    }
}