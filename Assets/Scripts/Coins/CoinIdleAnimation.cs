using UnityEngine;

public class CoinIdleAnimation : MonoBehaviour
{
    private static float _degreesPerSec = 30f;
    private static float _amplitude = 0.25f;
    private static float _frequency = 0.8f;
    private Vector3 _positionOffset;

    private void Start()
    {
        _positionOffset = transform.position;
        _positionOffset.y += 0.25f;
    }

    private void Update()
    {
        SetVerticalPosition();
        SetRotation();
    }

    private void SetVerticalPosition()
    {
        Vector3 pos = _positionOffset;
        pos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * _frequency) * _amplitude;
        transform.position = pos;
    }

    private void SetRotation()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * _degreesPerSec, 0f), Space.World);
    }
}
