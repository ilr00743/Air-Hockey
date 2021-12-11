using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

#if UNITY_EDITOR
        private void Start()
        {
            Debug.Log("Editor");
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