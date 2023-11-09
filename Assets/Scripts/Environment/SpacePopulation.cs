using UnityEngine;

public class SpacePopulation : MonoBehaviour
{
    public int CoinAmount { get; private set; }
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _collectibles;
    private GameObject[] _arrCoins;

    private void Awake()
    {
        string tag = gameObject.tag;
        Vector3 minCoords = Vector3.zero;
        Vector3 maxCoords = Vector3.zero;
        SetCoinAmount(tag);
        SetLimitCoordinates(tag, ref minCoords, ref maxCoords);
        PlaceCoins(minCoords, maxCoords);
    }

    private void SetCoinAmount(string tag)
    {
        int minCoinAmount = 1;
        int maxCoinAmount = 1;

        if (tag == "Room")
        {
            maxCoinAmount = 12;
        }
        else if (tag == "Corridor")
        {
            maxCoinAmount = 3;
        }

        CoinAmount = (int)Random.Range(minCoinAmount, maxCoinAmount);
    }

    private void SetLimitCoordinates(string tag, ref Vector3 min, ref Vector3 max)
    {
        // The coin scale is taken into account as not to have the coin placed within walls
        float coinScale = 0.5f;

        if (gameObject.tag == "Room")
        {
            // Default Unity plane (10x10)
            min.x = -5f + coinScale;
            max.x = 5f - coinScale;
            min.z = -5f + coinScale;
            max.z = 5f - coinScale;
        }
        else if (gameObject.tag == "Corridor")
        {
            // Based upon the default Unity plane (2x10)
            min.x = -1f + coinScale;
            max.x = 1f - coinScale;
            min.z = -5f + coinScale;
            max.z = 5f - coinScale;
        }
    }

    private void PlaceCoins(Vector3 minCoords, Vector3 maxCoords)
    {
        int i;
        Vector3 localPos = new Vector3(0f, _coinPrefab.transform.position.y, 0f);

        _arrCoins = new GameObject[CoinAmount];
        for (i = 0; i < _arrCoins.Length; ++i)
        {
            _arrCoins[i] = Instantiate(_coinPrefab) as GameObject;
            _arrCoins[i].transform.parent = _collectibles;
            localPos.x = Random.Range(minCoords.x, maxCoords.x);
            localPos.z = Random.Range(minCoords.z, maxCoords.z);
            _arrCoins[i].transform.localPosition = localPos;
        }
    }
}
