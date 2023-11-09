using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRespawn : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _checkpoint = Vector3.zero;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -1f)
            RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        transform.position = _checkpoint;
        _rb.velocity = Vector3.zero;
    }
}
