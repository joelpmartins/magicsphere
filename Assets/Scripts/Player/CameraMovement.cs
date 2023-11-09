using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private static Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }
}
