using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance { get; private set; }
    [SerializeField] private Transform _amountTransform;
    private int _count = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        TextGeneration.instance.Print(_amountTransform, _count.ToString());
    }

    public void UpdateCount()
    {
        ++_count;
        TextGeneration.instance.Print(_amountTransform, _count.ToString());
    }
}
