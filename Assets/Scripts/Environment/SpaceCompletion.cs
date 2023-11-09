using UnityEngine;

public class SpaceCompletion : MonoBehaviour
{
    [SerializeField] private Sound _spaceCompleted;
    [SerializeField] private Transform _collectibles;

    private void FixedUpdate()
    {
        if (_collectibles.childCount == 0)
        {
            _spaceCompleted.Play();
            this.enabled = false;
        }
    }
}
