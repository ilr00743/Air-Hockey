using UnityEngine;

public class AdaptiveCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private int _targetWidth;
    [SerializeField] private float _pixelToUnits;

    private void Start ()
    {
        var height = Mathf.RoundToInt(_targetWidth / (float)Screen.width * Screen.height);
        _camera.orthographicSize = height / _pixelToUnits / 2;
    }
}