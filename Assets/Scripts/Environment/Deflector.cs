using System;
using UnityEngine;

public class Deflector : MonoBehaviour
{
    private enum DeflectionType
    {
        Bumper,
        Jumper
    };

    [field: SerializeField] public bool IsActivated { get; private set; }
    [SerializeField] private Material _activatedMaterial, _deactivatedMaterial;
    private Renderer _rendererComponent;
    private DeflectionType _type;
    private float _bounceAmount;

    private void Awake()
    {
        _rendererComponent = GetComponent<Renderer>();
        _type = Enum.Parse<DeflectionType>(gameObject.name.Split(' ')[0]);
        _bounceAmount = _type == DeflectionType.Bumper ? 200f : 10f;
        SetActivationMaterial();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRb;
        if (IsActivated && other.CompareTag("Player"))
        {
            otherRb = other.GetComponent<Rigidbody>();
            if (otherRb == null)
                return;

            if (_type == DeflectionType.Bumper)
                BumperEffect(otherRb);
            else
                JumperEffect(otherRb);
        }
    }

    private void BumperEffect(Rigidbody otherRb)
    {
        Vector3 bounceDirection = -otherRb.velocity;
        otherRb.AddForce(bounceDirection * _bounceAmount);
    }

    private void JumperEffect(Rigidbody otherRb)
    {
        otherRb.velocity = new Vector3(0f, _bounceAmount, 0f);
    }

    private void SetActivationMaterial()
    {
        _rendererComponent.material = IsActivated ? _activatedMaterial : _deactivatedMaterial;
    }

    // Unused for now
    public void SwitchActivation()
    {
        IsActivated = !IsActivated;
        SetActivationMaterial();
    }
}
