using UnityEngine;

public class SpaceGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _roomPrefab;
    [SerializeField] private GameObject _corridorPrefab;
    private GameObject _roomParent, _corridorParent;
    private GameObject[] _arrRooms, _arrCorridors;

    private void Awake()
    {
        GenerateRooms();
        GenerateCorridors();
    }

    private void LateUpdate()
    {
        bool isAnySpaceNotComplete = false;

        foreach (GameObject go in _arrRooms)
        {
            isAnySpaceNotComplete = go.GetComponent<SpaceCompletion>().enabled;
            if (isAnySpaceNotComplete)
                return;
        }
        foreach (GameObject go in _arrCorridors)
        {
            isAnySpaceNotComplete = go.GetComponent<SpaceCompletion>().enabled;
            if (isAnySpaceNotComplete)
                return;
        }

        if (!isAnySpaceNotComplete)
            Victory.instance.DisplayVictoryPanel();
    }

    private void GenerateRooms()
    {
        int i;
        int nbrRooms = 1;

        _roomParent = new GameObject("Rooms");
        _arrRooms = new GameObject[nbrRooms];

        for (i = 0; i < _arrRooms.Length; ++i)
        {
            _arrRooms[i] = Instantiate(_roomPrefab) as GameObject;
            _arrRooms[i].name = "Room " + i;
            _arrRooms[i].transform.parent = _roomParent.transform;
        }
    }

    private void GenerateCorridors()
    {
        int i;
        int nbrCorridors = 2;

        _corridorParent = new GameObject("Corridors");
        _arrCorridors = new GameObject[nbrCorridors];

        for (i = 0; i < _arrCorridors.Length; ++i)
        {
            _arrCorridors[i] = Instantiate(_corridorPrefab) as GameObject;
            _arrCorridors[i].name = "Corridor " + i;
            _arrCorridors[i].transform.parent = _corridorParent.transform;

            // tmp
            if (i == 0)
                _arrCorridors[i].transform.position = new Vector3(11f, 0f, 0f);
            else if (i == 1)
                _arrCorridors[i].transform.position = new Vector3(-11f, 0f, 0f);
        }
    }
}
