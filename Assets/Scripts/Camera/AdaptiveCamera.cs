using UnityEngine;

public class AdaptiveCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _rink;
    
    void Start () {
        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = _rink.bounds.size.x / _rink.bounds.size.y;

        if(screenRatio >= targetRatio){
            _camera.orthographicSize = _rink.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            _camera.orthographicSize = _rink.bounds.size.y / 2 * differenceInSize;
        }
    }
}