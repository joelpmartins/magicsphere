using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] private Sound _coinCollected;
    private MeshRenderer _renderer;
    private Collider _collider;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _coinCollected.Play();
            HideObject();
            Invoke("DestroyObject", 0.5f);
            HUDManager.instance.UpdateCount();
        }
    }

    private void HideObject()
    {
        _renderer.enabled = false;
        _collider.enabled = false;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
