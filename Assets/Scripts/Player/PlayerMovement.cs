using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementValue;
    private float _horizontalInput, _verticalInput;
    private static float _maxSpeed = 20f;
    private float _speed = 15f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        CapSpeed();
    }

    private void OnEnable()
    {
        _movementValue.action.started += Movement;
        _movementValue.action.performed += Movement;
        _movementValue.action.canceled += Movement;
    }

    private void OnDisable()
    {
        _movementValue.action.started -= Movement;
        _movementValue.action.performed -= Movement;
        _movementValue.action.canceled -= Movement;
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        _horizontalInput = movementVector.x;
        _verticalInput = movementVector.y;
    }

    private void Move()
    {
        _rb.AddForce(new Vector3(_horizontalInput, 0f, _verticalInput) * _speed, ForceMode.Force);
    }

    private void CapSpeed()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
    }
}
